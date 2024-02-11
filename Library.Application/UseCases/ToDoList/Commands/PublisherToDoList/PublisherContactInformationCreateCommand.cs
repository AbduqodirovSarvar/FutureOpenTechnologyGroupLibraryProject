using Library.Domain.Entities;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Commands.PublisherToDoList
{
    public class PublisherContactInformationCreateCommand : IRequest<ContactInformation>
    {
        public Guid PublisherId { get; set; }
        public string Name { get; set; } = null!;
        public string Contact { get; set; } = null!;
    }
}
