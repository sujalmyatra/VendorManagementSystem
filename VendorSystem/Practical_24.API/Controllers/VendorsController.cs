using Microsoft.AspNetCore.Mvc;
using Practical_24.Application.DTOs.Vendors;
using Practical_24.Application.Interfaces;


namespace Practical_24.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendorsController : ControllerBase
{
    private readonly IVendorService _vendorService;

    public VendorsController(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }

    [HttpPost]
    public async Task<ActionResult<VendorResponse>> Create(
        CreateVendorRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _vendorService.CreateAsync(request, cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = response.Id },
            response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<VendorResponse>> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _vendorService.GetByIdAsync(id, cancellationToken);

        if (response is null)
            return NotFound("Vendor not found.");

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<VendorResponse>>> GetAll(
        CancellationToken cancellationToken)
    {
        var response = await _vendorService.GetAllAsync(cancellationToken);

        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id,
        CancellationToken cancellationToken)
    {
        await _vendorService.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}