using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.AddressToDoList
{
    public class CountryCreateCommand : IRequest<Country>
    {
        public CountryCreateCommand(string name)
        {
            CountryName = name;
        }
        public string CountryName { get; set; } = null!;
    }
}
