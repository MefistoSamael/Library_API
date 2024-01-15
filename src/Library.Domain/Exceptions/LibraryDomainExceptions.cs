using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class LibraryDomainException : Exception
    {
        public LibraryDomainException()
        { }

        public LibraryDomainException(string message)
            : base(message)
        { }

        public LibraryDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
