using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.Exceptions
{
    public class InvalidCustomerIdException : CustomException
    {
        public InvalidCustomerIdException() { }
        public InvalidCustomerIdException(string message) : base(message) { }
        public InvalidCustomerIdException(string message, Exception innerException) : base(message, innerException) { }
    }
}
