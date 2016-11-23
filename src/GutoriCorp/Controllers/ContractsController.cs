using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GutoriCorp.Data;
using GutoriCorp.Models.BusinessViewModels;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contract.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(long? id)
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

        // GET: Contracts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,accident_penalty_fee,contract_date,contract_type_id,created_by,created_on,frequency_id,late_fee,late_fee_type,lessee_id,lessor_id,modified_by,modified_on,rental_fee,status_id,thirdparty_fee")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(long? id)
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

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,accident_penalty_fee,contract_date,contract_type_id,created_by,created_on,frequency_id,late_fee,late_fee_type,lessee_id,lessor_id,modified_by,modified_on,rental_fee,status_id,thirdparty_fee")] Contract contract)
        {
            if (id != contract.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
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
    }
}
