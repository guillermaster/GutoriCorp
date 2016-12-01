using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GutoriCorp.Data;
using GutoriCorp.Data.Models;
using GutoriCorp.Data.Operations;
using GutoriCorp.Models.BusinessViewModels;

namespace GutoriCorp.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicle.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            var model = new VehicleViewModel();
            model.Makes = GetAllMakes();
            model.Models = new List<SelectListItem>();
            return View(model);
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,_new,body_hull_id,color_id,created_by,created_on,cyl_prop,date_issued,document_num,fuel_id,make_id,model_id,modified_by,modified_on,reading_miles,seats,tlc_plate,type_title,vin_code,wt_sts_lgth,year")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,_new,body_hull_id,color_id,created_by,created_on,cyl_prop,date_issued,document_num,fuel_id,make_id,model_id,modified_by,modified_on,reading_miles,seats,tlc_plate,type_title,vin_code,wt_sts_lgth,year")] Vehicle vehicle)
        {
            if (id != vehicle.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.id))
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
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.id == id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

//        [HttpPost]
        public JsonResult Models(short year)
        {
            //if (year == 2011)
            //{
            //    return Json(
            //        Enumerable.Range(1, 3).Select(x => new { value = x, text = x }),
            //        JsonRequestBehavior.AllowGet
            //    );
            //}
            return Json(
                GetMakeModels(year).Select(x => new { value = x.Value, text = x.Text })//,
                //JsonRequestBehavior.AllowGet
            );
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.id == id);
        }

        private IEnumerable<SelectListItem> GetAllMakes()
        {
            var selectList = new List<SelectListItem>();

            var vehMakesDataOp = new VehicleMakeData(_context);
            var makes = vehMakesDataOp.GetMakes();

            foreach (var make in makes)
            {
                selectList.Add(new SelectListItem
                {
                    Value = make.id.ToString(),
                    Text = make.name
                });
            }

            return selectList;
        }

        private IEnumerable<SelectListItem> GetMakeModels(short modelId)
        {
            var selectList = new List<SelectListItem>();

            var vehMakesDataOp = new VehicleMakeData(_context);
            var models = vehMakesDataOp.GetMakeModels(modelId);

            foreach (var model in models)
            {
                selectList.Add(new SelectListItem
                {
                    Value = model.id.ToString(),
                    Text = model.name
                });
            }

            return selectList;
        }
    }
}
