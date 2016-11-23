using Microsoft.AspNetCore.Mvc;

namespace GutoriCorp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}