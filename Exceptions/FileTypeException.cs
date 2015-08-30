using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuneTracker.Exceptions
{
    class FileTypeException : Exception
    {
        public FileTypeException() : base() { }

        public FileTypeException(string message) : base(message) { }

        public FileTypeException(string message, Exception inner) : base(message, inner) { }
    }
}
