using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Practical_24.Application.DTOs.Customers;
using Practical_24.Application.DTOs.Invoices;
using Practical_24.Application.DTOs.Vendors;
using Practical_24.Application.Mappings;
using Practical_24.Application.Services;
using Practical_24.Application.Validators;
using Practical_24.Domain.Factories;
using Practical_24.Domain.Interfaces;

using Practical_24.Infrastructure.Repositories;
using Practical_24.Infrastructure.Data;
using Practical_24.Application.Interfaces;
using Practical_24.Application.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(ApplicationMappingProfile).Assembly);

builder.Services.AddScoped<IValidator<CreateCustomerRequest>, CreateCustomerRequestValidator>();
builder.Services.AddScoped<IValidator<CreateVendorRequest>, CreateVendorRequestValidator>();
builder.Services.AddScoped<IValidator<CreateInvoiceItemRequest>, CreateInvoiceItemRequestValidator>();
builder.Services.AddScoped<IValidator<CreateOrderRequest>, CreateOrderRequestValidator>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddSingleton<IPaymentMethodFactory, CashPaymentFactory>();
builder.Services.AddSingleton<IPaymentMethodFactory, UpiPaymentFactory>();

builder.Services.AddSingleton<PaymentMethodFactoryProvider>();

builder.Services.AddSingleton<ApplicationEvents>();
var app = builder.Build();

//Simple

//var applicationEvents = app.Services.GetRequiredService<ApplicationEvents>();
//applicationEvents.EntityCreated += () => { Console.WriteLine("Entity created event"); };
//applicationEvents.OrderSucceeded += () => { Console.WriteLine("OrderSucceeded"); };


//Detailed
var applicationEvent = app.Services.GetRequiredService<ApplicationEvents>();

applicationEvent.EntityCreated += (sender, args) =>
{
    Console.WriteLine($"{args.Name} created event raised. Id: {args.Id}");
};

applicationEvent.OrderSucceeded += (sender, args) =>
{
    Console.WriteLine(
        $"Order succeeded event raised. InvoiceId: {args.InvoiceId}, PaymentId: {args.PaymentId}, Amount: {args.Amount}");
};



app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthentication();

app.UseRouting();
app.MapControllers();

app.Run();

