using Microsoft.AspNetCore.Mvc;
using Practical_24.Application.DTOs.Invoices;
using Practical_24.Application.Interfaces;
using Practical_24.Application.Interfaces.Services;

namespace Practical_24.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult<OrderResponse>> CreateOrder(
        CreateOrderRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _orderService.CreateOrderAsync(request, cancellationToken);

        return Ok(response);
    }
}