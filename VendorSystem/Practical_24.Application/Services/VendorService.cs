using AutoMapper;
using FluentValidation;
using Practical_24.Application.DTOs.Vendors;
using Practical_24.Application.Events;
using Practical_24.Application.Interfaces;
using Practical_24.Domain.Entities;
using Practical_24.Domain.Interfaces;

namespace Practical_24.Application.Services;

public class VendorService(IUnitOfWork uow, IMapper mapper, IValidator<CreateVendorRequest> validator, ApplicationEvents events) : IVendorService
{
    public async Task<VendorResponse> CreateAsync(CreateVendorRequest req,CancellationToken token = default)
    {
        await validator.ValidateAndThrowAsync(req);

        var v = new Vendor(req.Name, req.Email);
        await uow.Vendors.AddAsync(v, token);
        await uow.SaveChangesAsync(token);

        events.RaiseEntityCreated(nameof(Vendor), v.Id);
        //events.RaiseEntityCreated();
        return mapper.Map<VendorResponse>(v);
    }

    public async Task<VendorResponse?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        var v = await uow.Vendors.GetByIdAsync(id, token);
        return v is null ? null : mapper.Map<VendorResponse>(v);
    }

    public async Task<List<VendorResponse>> GetAllAsync(CancellationToken token = default)
    {
        var v = await uow.Vendors.GetAllAsync(token);

        return mapper.Map<List<VendorResponse>>(v);
    }

    public async Task DeleteAsync(Guid id, CancellationToken token = default)
    {
        var v = await uow.Vendors.GetByIdAsync(id, token);

        if (v is null)
            throw new InvalidOperationException("not found");

        uow.Vendors.Delete(v);
        await uow.SaveChangesAsync(token);

    }
}
