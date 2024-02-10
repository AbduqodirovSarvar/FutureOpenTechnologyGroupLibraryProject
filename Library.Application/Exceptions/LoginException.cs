﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException() : base("Login or password incorrect!") { }
    }
}
