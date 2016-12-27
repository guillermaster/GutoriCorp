using GutoriCorp.Data;
using GutoriCorp.Data.Operations;
using GutoriCorp.Models.GeneralViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GutoriCorp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var dashboardDataOp = new DashboardData(_context);
            var model = new DashboardViewModel();
            model.PaymentsThisWeek = dashboardDataOp.GetPaymentsSummaryPerWeek();
            return View(model);
        }


    }
}