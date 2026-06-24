using FluentValidation;
using Practical_24.Application.DTOs.Invoices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Validators
{
    public class CreateOrderRequestValidator  :AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.VendorId).NotEmpty();
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Items).NotEmpty();
            RuleFor(x => x.FailuresBeforeSucceess).InclusiveBetween(0, 6);
        }
    }
}
