using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models.ViewModels
{
    public record UserViewModel
         (
              Guid Id,
              string FullName,
              string Email,
              string Login,
              string RoleName,
              DateTime CreatedTime
        );
}
