using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuneTracker.Exceptions
{
    class AppPageException : Exception
    {
        public AppPageException() : base() { }

        public AppPageException(string message) : base(message) { }

        public AppPageException(string message, Exception inner) : base(message, inner) { }
    }
}
