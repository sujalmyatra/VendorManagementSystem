using AutoMapper;
using FluentValidation;
using Practical_24.Application.DTOs.Customers;
using Practical_24.Application.Events;
using Practical_24.Application.Interfaces;
using Practical_24.Domain.Entities;
using Practical_24.Domain.Interfaces;

namespace Practical_24.Application.Services;

public class CustomerService(IUnitOfWork uow, IMapper mapper, IValidator<CreateCustomerRequest> validator, ApplicationEvents events)
    : ICustomerService
{
    public async Task<CustomerResponse> CreateAsync(CreateCustomerRequest req,CancellationToken token= default)
    {
        await validator.ValidateAndThrowAsync(req, token);

        var c = new Customer(req.Name, req.Email);

        await uow.Customers.AddAsync(c, token);
        await uow.SaveChangesAsync(token);

        events.RaiseEntityCreated(nameof(Customer), c.Id);
        //events.RaiseEntityCreated();
        return mapper.Map<CustomerResponse>(c);
    }

    public async Task<CustomerResponse?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        var c = await uow.Customers.GetByIdAsync(id, token);

        return c is null ? null : mapper.Map<CustomerResponse>(c);
    }

    public async Task<List<CustomerResponse>> GetAllAsync(CancellationToken token = default)
    {
        var c = await uow.Customers.GetAllAsync(token);
        return mapper.Map<List<CustomerResponse>>(c);
    }

    public async Task DeleteAsync(Guid id, CancellationToken token = default)
    {

        var c = await uow.Customers.GetByIdAsync(id, token);

        if (c is null)
            throw new InvalidOperationException("not found");

        uow.Customers.Delete(c);
        await uow.SaveChangesAsync(token);

            
    }
}
