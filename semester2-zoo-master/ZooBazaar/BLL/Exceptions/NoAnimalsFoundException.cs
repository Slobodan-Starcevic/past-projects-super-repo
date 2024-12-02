using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class NoAnimalsFoundException : Exception
    {
        public NoAnimalsFoundException() : base() { }

        public NoAnimalsFoundException(string message) : base(message) { }

        public NoAnimalsFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
