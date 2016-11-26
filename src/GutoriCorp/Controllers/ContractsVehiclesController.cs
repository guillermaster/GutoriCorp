using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GutoriCorp.Models.BusinessViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GutoriCorp.Controllers
{
    public class ContractsVehiclesController : Controller
    {
        // GET: ContractsVehicles
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContractsVehicles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContractsVehicles/Create
        public ActionResult Create()
        {
            var model = new ContractVehicleViewModel();
            model.AvailableVehicles = new List<SelectListItem>();
            return View(model);
        }

        // POST: ContractsVehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContractsVehicles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContractsVehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContractsVehicles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContractsVehicles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}