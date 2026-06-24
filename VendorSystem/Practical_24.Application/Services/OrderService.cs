using AutoMapper;
using FluentValidation;
using Practical_24.Application.DTOs.Invoices;
using Practical_24.Application.DTOs.Payments;
using Practical_24.Application.Events;
using Practical_24.Application.Interfaces;
using Practical_24.Domain.Entities;
using Practical_24.Domain.Interfaces;

namespace Practical_24.Application.Services
{
    public class OrderService
        (IUnitOfWork uow, IMapper mapper, IPaymentService paymentService, IValidator<CreateOrderRequest> validator, ApplicationEvents events)
        : IOrderService
    {
        public async Task<OrderResponse> CreateOrderAsync(CreateOrderRequest req, CancellationToken token = default)
        {
            await validator.ValidateAndThrowAsync(req, token);

            var customer = await uow.Customers.GetByIdAsync(req.CustomerId, token);
            if (customer is null) throw new InvalidOperationException("customer not found");

            var vendor = await uow.Vendors.GetByIdAsync(req.VendorId, token);
            if (vendor is null) throw new InvalidOperationException("vendor not found");


            var invoice = new Invoice(req.CustomerId, req.VendorId);

            await uow.Invoices.AddAsync(invoice, token);

            var invoiceItems = req.Items
                .Select(item => new InvoiceList(invoice.Id, item.ItemName, item.Quantity, item.Price))
                .ToList();

            foreach( var item in invoiceItems)
            {
                await uow.InvoiceLists.AddAsync(item, token);
            }

            var totalAmount = invoiceItems.Sum(item => item.Quantity * item.Price);

            var payment = new Payment(invoice.Id, req.Type, totalAmount);

            await uow.Payments.AddAsync(payment, token);

            await paymentService.ProcessPaymentAsync(payment, req.FailuresBeforeSucceess, token);

            //events.RaiseEntityCreated();
            //events.RaiseOrderSucceeded();

            //event
            events.RaiseEntityCreated(nameof(Invoice), invoice.Id);

            events.RaiseOrderSucceeded(invoice.Id, payment.Id, payment.Amount);

            var itemResponses = mapper.Map<List<InvoiceItemResponse>>(invoiceItems);
            var paymentResponse = mapper.Map<PaymentResponse>(payment);

            return new OrderResponse(invoice.Id, invoice.CustomerId, invoice.VendorId, invoice.InvoiceDate, itemResponses, paymentResponse);

        }
    }
}
