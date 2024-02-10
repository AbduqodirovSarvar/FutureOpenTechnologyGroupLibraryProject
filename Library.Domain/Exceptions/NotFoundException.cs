using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Exceptions
{
    public class NotFoundException<T> : Exception
    {
        public NotFoundException()
            : base($"{typeof(T).Name} is not found from database.")
        { }

        public NotFoundException(string message)
            : base(message)
        { }

        public NotFoundException(string message, Exception exception)
            : base(message, exception)
        { }
    }
}
