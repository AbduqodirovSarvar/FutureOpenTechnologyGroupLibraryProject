using Library.Application.Models.ViewModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.UseCases.ToDoList.Queries.PublishertoDoList
{
    public class GetPublisherByIdQuery : IRequest<PublisherViewModel>
    {
        public GetPublisherByIdQuery(Guid id)
        {
            Id = id;
        }
        [Required]
        public Guid Id { get; set; }
    }
}
