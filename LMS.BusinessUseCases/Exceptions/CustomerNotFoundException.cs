using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.Exceptions
{
    public class CustomerNotFoundException : CustomException
    {
        public CustomerNotFoundException() { }
        public CustomerNotFoundException(string message) : base(message) { }
        public CustomerNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
