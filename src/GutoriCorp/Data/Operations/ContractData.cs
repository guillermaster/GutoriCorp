using GutoriCorp.Common;
using GutoriCorp.Data.Models;
using GutoriCorp.Models.BusinessViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GutoriCorp.Data.Operations
{
    public class ContractData
    {
        private readonly ApplicationDbContext _context;

        public ContractData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(ContractViewModel contract)
        {
            _context.Add(GetEntity(contract));
            await _context.SaveChangesAsync();
        }

        private Contract GetEntity(ContractViewModel contractVm)
        {
            var contract = new Contract {
                lessee_id = contractVm.lessee_id,
                lessor_id = contractVm.lessor_id,
                contract_type_id = contractVm.contract_type_id,
                frequency_id = contractVm.frequency_id,
                late_fee_type = contractVm.late_fee_type,
                status_id = (short)Enums.GeneralStatus.Active,
                contract_date = contractVm.contract_date,
                rental_fee = contractVm.rental_fee,
                late_fee = contractVm.late_fee,
                thirdparty_fee = contractVm.thirdparty_fee,
                accident_penalty_fee = contractVm.accident_penalty_fee,
                created_on = DateTime.Now,
                created_by = contractVm.created_by,
                modified_on = DateTime.Now,
                modified_by = contractVm.modified_by
            };
            return contract;
        }
    }
}
