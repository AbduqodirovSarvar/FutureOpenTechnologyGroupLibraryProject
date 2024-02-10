using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Models.Dtos
{
    public record ResetPasswordDto(string Email, int ConfirmationCode);
}
