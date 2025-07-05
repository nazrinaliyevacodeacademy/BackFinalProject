using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Application.Exceptions
{
        public class UnauthorizedAccessAppException : Exception
        {
            public UnauthorizedAccessAppException(string message) : base(message)
            {
            }
        }
}
