using Microsoft.AspNetCore.Mvc;
using VendorAccessGovernance.Application.Abstractions;

namespace VendorAccessGovernance.Web.Controllers
{
    public class VendorsController : Controller
    {
        private readonly IVendorService _service;

        public VendorsController(IVendorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var request = await _service.GetAllAsync();
            return View(request);
        }
    }
}
