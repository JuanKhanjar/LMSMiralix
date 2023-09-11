using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.Exceptions
{
    public class GroupNotFoundException : CustomException
    {
        public GroupNotFoundException() { }
        public GroupNotFoundException(string message) : base(message) { }
        public GroupNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
