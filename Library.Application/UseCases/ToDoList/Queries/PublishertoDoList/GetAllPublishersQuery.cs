using Library.Application.Models.ViewModels;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Queries.PublishertoDoList
{
    public class GetAllPublishersQuery : IRequest<List<PublisherViewModel>>
    {
        public GetAllPublishersQuery() { }
    }
}
