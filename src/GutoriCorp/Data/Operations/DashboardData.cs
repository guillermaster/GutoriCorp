using GutoriCorp.Common;
using GutoriCorp.Models.GeneralViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GutoriCorp.Data.Operations
{
    public class DashboardData
    {
        private readonly ApplicationDbContext _context;

        public DashboardData(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<DashboardSerieViewModel> GetPaymentsSummaryPerWeek()
        {
            var series = new List<DashboardSerieViewModel>();
            var weekStartEnd = Dates.GetWeekBeginEndDates(DateTime.Now);

            // query paid amount
            var payments = _context.Payment.Where(p =>
                                            p.status_id == (short)Enums.GeneralStatus.Active &&
                                            p.payment_date >= weekStartEnd.Item1 &&
                                            p.payment_date <= weekStartEnd.Item2).ToList();

            var paymentsTotAmount = payments.Sum(p => p.total_paid_amount);
            series.Add(
                new DashboardSerieViewModel {
                    Title = "Collected payments",
                    Value = paymentsTotAmount.ToString(),
                    Color = "#FFC107"
            });

            // query pending amount
                var pendingTotAmount = _context.Contract.Where(c => !payments.Any(p => p.contract_id == c.id)).Sum(c => c.rental_fee);

            var ticketsInPendingCont = (from tic in _context.Ticket
                                        join con in _context.Contract on tic.vehicle_id equals con.vehicle_id
                                        where !payments.Any(p => p.contract_id == con.id)
                                        select tic.fine_amount).Sum();

            pendingTotAmount += ticketsInPendingCont;
            series.Add(
                new DashboardSerieViewModel
                {
                    Title = "Pending",
                    Value = pendingTotAmount.ToString(),
                    Color = "#009688"
                });

            return series;
        }
    }
}
