// Web/Controllers/AccessRequestsMvcController.cs
using Microsoft.AspNetCore.Mvc;
using VendorAccessGovernance.Application.Abstractions;
using VendorAccessGovernance.Application.DTOs;

namespace VendorAccessGovernance.Web.Controllers;

public class AccessRequestsController : Controller
{
    private readonly IAccessRequestService _service;

    public AccessRequestsController(IAccessRequestService service)
    {
        _service = service;
    }

    // GET: /AccessRequests
    public async Task<IActionResult> Index()
    {
        var requests = await _service.GetAllAsync();
        return View(requests);
    }

    // GET: /AccessRequests/Create
    public IActionResult Create()
    {
        return View(new CreateAccessRequestDto());
    }

    // POST: /AccessRequests/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateAccessRequestDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var created = await _service.CreateAsync(dto);
        // dopo la creazione, torniamo alla lista
        return RedirectToAction(nameof(Index));
    }
}