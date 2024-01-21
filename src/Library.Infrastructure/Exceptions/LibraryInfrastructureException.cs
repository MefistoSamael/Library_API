using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for infrastructure exceptions
    /// </summary>
    public class LibraryInfrastructureException : Exception
    {
        public LibraryInfrastructureException()
        { }

        public LibraryInfrastructureException(string message)
            : base(message)
        { }

        public LibraryInfrastructureException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

}
