using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GutoriCorp.Data;
using GutoriCorp.Models.BusinessViewModels;
using GutoriCorp.Data.Operations;
using GutoriCorp.Models.GeneralViewModels;
using GutoriCorp.Common;

namespace GutoriCorp.Controllers
{
    public class ContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContractsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Contracts
        //public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            var contractDataOp = new ContractData(_context);
            var contracts = contractDataOp.GetAll();
            return View(contracts);
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            try
            {
                var contractDataOp = new ContractData(_context);
                var contract = await contractDataOp.Get(id);
                PopulateContractOptionsLists(contract);
                return View(contract);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            var model = new ContractViewModel();
            PopulateContractOptionsLists(model);

            return View(model);
        }
        

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("id,accident_penalty_fee,contract_date,contract_type_id,created_by,created_on,frequency_id,late_fee,late_fee_type,lessee_id,lessor_id,modified_by,modified_on,rental_fee,status_id,thirdparty_fee")] ContractViewModel contract)
        public async Task<IActionResult> Create(ContractViewModel contract)
        {
            if (ModelState.IsValid)
            {
                //TODO: set up the current user id 
                contract.created_by = 1;
                contract.modified_by = 1;
                contract.status_id = (short)Enums.GeneralStatus.Active;

                var contractDataOp = new ContractData(_context);
                await contractDataOp.Add(contract);
                return RedirectToAction("Index");
            }
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            try
            {
                var contractDataOp = new ContractData(_context);
                var contract = await contractDataOp.Get(id);
                PopulateContractOptionsLists(contract);
                return View(contract);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("id,accident_penalty_fee,contract_date,contract_type_id,created_by,created_on,frequency_id,late_fee,late_fee_type,lessee_id,lessor_id,modified_by,modified_on,rental_fee,status_id,thirdparty_fee")] ContractViewModel contract)
        public async Task<IActionResult> Edit(long id, ContractViewModel contract)
        {
            if (id != contract.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var contractDataOp = new ContractData(_context);
                    await contractDataOp.Update(contract);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract.SingleOrDefaultAsync(m => m.id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var contract = await _context.Contract.SingleOrDefaultAsync(m => m.id == id);
            _context.Contract.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContractExists(long id)
        {
            return _context.Contract.Any(e => e.id == id);
        }

        private IEnumerable<SelectListItem> GetGeneralCatalogValues(Common.Enums.GeneralCatalog catalog)
        {
            var selectList = new List<SelectListItem>();

            var gralCatalogDataOp = new GeneralCatalogData(_context);
            var contractTypes = gralCatalogDataOp.GetCatalogValues(catalog);

            foreach(var contractType in contractTypes)
            {
                selectList.Add(new SelectListItem
                {
                    Value = contractType.id.ToString(),
                    Text = contractType.title
                });
            }

            return selectList;
        }
        

        private IEnumerable<SelectListItem> GetAllOwners()
        {
            var selectList = new List<SelectListItem>();

            var ownerDataOp = new OwnerData(_context);
            var owners = ownerDataOp.GetOwners();

            foreach(var owner in owners)
            {
                selectList.Add(new SelectListItem
                {
                    Value = owner.id.ToString(),
                    Text = owner.first_name + " " + owner.last_name
                });
            }

            return selectList;
        }

        private IEnumerable<SelectListItem> GetAllDrivers()
        {
            var selectList = new List<SelectListItem>();

            var driverDataOp = new DriverData(_context);
            var drivers = driverDataOp.GetDrivers();

            foreach (var driver in drivers)
            {
                selectList.Add(new SelectListItem
                {
                    Value = driver.id.ToString(),
                    Text = driver.first_name + " " + driver.last_name
                });
            }

            return selectList;
        }

        private void PopulateContractOptionsLists(ContractViewModel contract)
        {
            contract.Owners = GetAllOwners();
            contract.Drivers = GetAllDrivers();
            contract.ContractTypes = GetGeneralCatalogValues(Enums.GeneralCatalog.ContractType);
            contract.ContractFrequencies = GetGeneralCatalogValues(Enums.GeneralCatalog.ContractFrequency);
            contract.ContractLateFeeTypes = GetGeneralCatalogValues(Enums.GeneralCatalog.ContractLateFeeType);
        }
    }
}
