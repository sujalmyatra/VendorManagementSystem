using FluentValidation;
using Practical_24.Application.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Validators
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);

            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(100);
        }
    }
}
