﻿using Library.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public sealed class Student : PersonBase
    {
        public Student() { }

        public Student(string fullName, string email)
            :base(fullName, email) 
        { }
    }
}