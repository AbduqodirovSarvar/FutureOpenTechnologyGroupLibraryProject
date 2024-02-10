using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Commands.PublisherToDoList
{
    public class PublisherContactInformationCreateCommand : IRequest<ContactInformation>
    {
        public Guid PublisherId { get; set; }
        public string Name { get; set; } = null!;
        public string Contact { get; set; } = null!;
    }
}
