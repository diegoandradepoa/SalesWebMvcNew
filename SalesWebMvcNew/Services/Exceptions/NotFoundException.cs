using Microsoft.AspNetCore.Builder;
using System;

namespace SalesWebMvcNew.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
