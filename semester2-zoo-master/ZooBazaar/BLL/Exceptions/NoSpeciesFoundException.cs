using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class NoSpeciesFoundException : Exception
    {
        public NoSpeciesFoundException() : base() { }

        public NoSpeciesFoundException(string message) : base(message) { }

        public NoSpeciesFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
