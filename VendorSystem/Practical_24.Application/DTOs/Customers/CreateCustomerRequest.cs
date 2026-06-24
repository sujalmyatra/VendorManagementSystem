using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.DTOs.Customers
{
    public sealed record CreateCustomerRequest(string Name, string Email);
    
}
