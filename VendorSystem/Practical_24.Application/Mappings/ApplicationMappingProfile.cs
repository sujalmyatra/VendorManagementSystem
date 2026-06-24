using AutoMapper;
using Practical_24.Application.DTOs.Customers;
using Practical_24.Application.DTOs.Invoices;
using Practical_24.Application.DTOs.Payments;
using Practical_24.Application.DTOs.Vendors;
using Practical_24.Domain.Entities;

namespace Practical_24.Application.Mappings
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Customer, CustomerResponse>();
            CreateMap<Vendor, VendorResponse>();
            CreateMap<Payment, PaymentResponse>();
            CreateMap<InvoiceList, InvoiceItemResponse>().ForCtorParam("Total", option => option.MapFrom(source => source.Quantity * source.Price);
        }
    }
}
