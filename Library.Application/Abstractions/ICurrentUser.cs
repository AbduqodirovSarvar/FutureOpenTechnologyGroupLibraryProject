using Library.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Abstractions
{
    public interface ICurrentUser
    {
        Guid UserId { get; }
        //UserRole UserRole { get; }
    }
}
