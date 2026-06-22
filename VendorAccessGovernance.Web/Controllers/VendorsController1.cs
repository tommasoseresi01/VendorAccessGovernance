using Microsoft.AspNetCore.Mvc;

namespace VendorAccessGovernance.Web.Controllers
{
    public class VendorsController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
