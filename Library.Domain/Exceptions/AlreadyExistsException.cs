using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Exceptions
{
    public class AlreadyExistsException<T> : Exception
    {
        public AlreadyExistsException()
            : base($"{typeof(T).Name} already existed to database.")
        { }

        public AlreadyExistsException(string message)
            : base(message)
        { }

        public AlreadyExistsException(string message, Exception exception)
            : base(message, exception)
        { }
    }
}
