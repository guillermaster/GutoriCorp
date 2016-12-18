using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GutoriCorp.Models.BusinessViewModels;
using GutoriCorp.Data.Models;
using static GutoriCorp.Common.Enums;

namespace GutoriCorp.Data.Operations
{
    public class PaymentData
    {
        private readonly ApplicationDbContext _context;

        public PaymentData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(PaymentViewModel payment)
        {
            _context.Add(GetEntity(payment));
            await _context.SaveChangesAsync();
        }

        public PaymentViewModel GetNextPaymentPeriodInit(long contractId)
        {
            var contractDataOp = new ContractData(_context);
            var contract = contractDataOp.Get(contractId);
            
            DateTime nextDueDate;
                        
            var latestPayment = _context.Payment.Where(p => p.contract_id == contractId).OrderByDescending(p => p.id)
                            .Select(p => 
                                new Payment {
                                    id = p.id,
                                    period = p.period,
                                    payment_date = p.payment_date,
                                    due_date = p.due_date
                                })
                            .FirstOrDefault();

            if(latestPayment == null)
            {
                nextDueDate = contract.contract_date;

                switch (contract.frequency_id)
                {
                    case (short)PaymentFrequency.Weekly:
                        var weekDayNum = (int)nextDueDate.DayOfWeek;
                        var daysToAdd = ((contract.due_day ?? 1) - weekDayNum) + 7;
                        nextDueDate = nextDueDate.AddDays(daysToAdd);
                        break;
                    case (short)PaymentFrequency.Monthly:
                        nextDueDate = nextDueDate.AddMonths(1);
                        nextDueDate = new DateTime(nextDueDate.Year, nextDueDate.Month, contract.due_day ?? 1);
                        break;
                    default:
                        throw new System.IO.InvalidDataException("Invalid contract payment frequency");
                }
            }
            else
            {
                switch (contract.frequency_id)
                {
                    case (short)PaymentFrequency.Weekly:
                        nextDueDate = latestPayment.due_date.AddDays(7);
                        break;
                    case (short)PaymentFrequency.Monthly:
                        nextDueDate = latestPayment.due_date.AddMonths(1);
                        break;
                    default:
                        throw new System.IO.InvalidDataException("Invalid contract payment frequency");
                }
            }

            short nextPeriod = 1;
            nextPeriod += (latestPayment != null ? latestPayment.period : (short)0);

            var nextPayment = GetViewModel(contract);
            nextPayment.period = nextPeriod;
            nextPayment.due_date = nextDueDate;

            if(latestPayment != null)
            {
                nextPayment.previous_credit = latestPayment.credit;
                nextPayment.previous_balance = latestPayment.balance;
            }

            nextPayment.late = DateTime.Now > nextPayment.due_date;

            if (!nextPayment.late)
            {
                nextPayment.late_fee = 0;
            }

            nextPayment.total_due_amount = nextPayment.rental_fee + 
                nextPayment.late_fee + nextPayment.previous_balance - nextPayment.previous_credit;

            return nextPayment;
        }
                
        public static PaymentViewModel GetViewModel(ContractViewModel contract)
        {
            var paymentVm = new PaymentViewModel
            {
                contract_id = contract.id,
                lessor = contract.lessor,
                lessee = contract.lessee,
                due_day = contract.due_day ?? 0,
                frequency_id = contract.frequency_id ?? 0,
                rental_fee = contract.rental_fee ?? 0,
                late_fee = contract.late_fee ?? 0
            };

            return paymentVm;
        }

        private static Payment GetEntity(PaymentViewModel paymentVm)
        {
            var payment = new Payment
            {
                contract_id = paymentVm.contract_id,
                period = paymentVm.period,
                due_date = paymentVm.due_date,
                payment_date = DateTime.Now,
                late = paymentVm.late,
                tickets = paymentVm.tickets,
                thirdparty = paymentVm.thirdparty,
                rental_fee = paymentVm.rental_fee,
                late_fee = paymentVm.late_fee,
                thirdparty_fee = paymentVm.thirdparty_fee,
                tickets_fee = paymentVm.tickets_fee,
                total_due_amount = paymentVm.total_due_amount,
                total_paid_amount = paymentVm.total_paid_amount,
                balance = paymentVm.total_due_amount > paymentVm.total_paid_amount ?
                            paymentVm.total_due_amount - paymentVm.total_paid_amount : 0,
                credit = paymentVm.total_paid_amount > paymentVm.total_due_amount ?
                            paymentVm.total_paid_amount - paymentVm.total_due_amount : 0,
                status_id = (short)GeneralStatus.Active,
                created_on = DateTime.Now,
                created_by = paymentVm.created_by,
                modified_on = DateTime.Now,
                modified_by = paymentVm.modified_by
            };
            return payment;
        }
    }
}
