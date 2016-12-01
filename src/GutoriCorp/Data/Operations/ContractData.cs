﻿using GutoriCorp.Common;
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

        public List<ContractViewModel> GetAll()
        {
            var contractsQry = from cont in _context.Contract
                               join own in _context.Owner on cont.lessor_id equals own.id
                               join driv in _context.Driver on cont.lessee_id equals driv.id
                               join contType in _context.GeneralCatalogValues on cont.contract_type_id equals contType.id
                               join frec in _context.GeneralCatalogValues on cont.frequency_id equals frec.id
                               join stat in _context.GeneralCatalogValues on cont.status_id equals stat.id
                               select new ContractViewModel
                               {
                                   id = cont.id,
                                   lessor_id = cont.lessor_id,
                                   lessor = own.first_name + " " + own.last_name,
                                   lessee_id = cont.lessee_id,
                                   lessee = driv.first_name + " " + driv.last_name,
                                   contract_type_id = cont.contract_type_id,
                                   contract_type = contType.title,
                                   frequency_id = cont.frequency_id,
                                   frequency = frec.title,
                                   contract_date = cont.contract_date,
                                   rental_fee = cont.rental_fee,
                                   late_fee_type_id = cont.late_fee_type_id,
                                   late_fee = cont.late_fee,
                                   thirdparty_fee = cont.thirdparty_fee,
                                   accident_penalty_fee = cont.accident_penalty_fee,
                                   status_id = cont.status_id,
                                   status = stat.title,
                                   created_on = cont.created_on,
                                   created_by = cont.created_by,
                                   modified_on = cont.modified_on,
                                   modified_by = cont.modified_by
                               };

            return contractsQry.ToList();
        }

        private Contract GetEntity(ContractViewModel contractVm)
        {
            var contract = new Contract {
                lessee_id = contractVm.lessee_id,
                lessor_id = contractVm.lessor_id,
                contract_type_id = contractVm.contract_type_id,
                frequency_id = contractVm.frequency_id,
                late_fee_type_id = contractVm.late_fee_type_id,
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

        private ContractViewModel GetViewModel(Contract contract)
        {
            var contractVm = new ContractViewModel
            {
                id = contract.id,
                lessee_id = contract.lessee_id,
                lessor_id = contract.lessor_id,
                contract_type_id = contract.contract_type_id,
                frequency_id = contract.frequency_id,
                late_fee_type_id = contract.late_fee_type_id,
                status_id = contract.status_id,
                contract_date = contract.contract_date,
                rental_fee = contract.rental_fee,
                late_fee = contract.late_fee,
                thirdparty_fee = contract.thirdparty_fee,
                accident_penalty_fee = contract.accident_penalty_fee,
                created_on = DateTime.Now,
                created_by = contract.created_by,
                modified_on = DateTime.Now,
                modified_by = contract.modified_by                
            };
            return contractVm;
        }
    }
}