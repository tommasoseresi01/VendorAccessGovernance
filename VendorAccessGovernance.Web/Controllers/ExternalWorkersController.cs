using Microsoft.AspNetCore.Mvc;
using VendorAccessGovernance.Application.Abstractions;

namespace VendorAccessGovernance.Web.Controllers
{
    public class ExternalWorkersController : Controller
    {

        private readonly IExternalWorkerService _service;

        public ExternalWorkersController(IExternalWorkerService service)
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
