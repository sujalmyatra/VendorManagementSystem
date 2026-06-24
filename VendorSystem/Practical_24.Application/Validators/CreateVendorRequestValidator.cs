using FluentValidation;
using Practical_24.Application.DTOs.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Validators
{
    public class CreateVendorRequestValidator : AbstractValidator<CreateVendorRequest>
    {
        public CreateVendorRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
