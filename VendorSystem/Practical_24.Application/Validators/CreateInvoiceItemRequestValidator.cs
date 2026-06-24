using FluentValidation;
using Practical_24.Application.DTOs.Invoices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Validators
{
    public class CreateInvoiceItemRequestValidator : AbstractValidator<CreateInvoiceItemRequest>
    {
        public CreateInvoiceItemRequestValidator()
        {
            RuleFor(x => x.ItemName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}
