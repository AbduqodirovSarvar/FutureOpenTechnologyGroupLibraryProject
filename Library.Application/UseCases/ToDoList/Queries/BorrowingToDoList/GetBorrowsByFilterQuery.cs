using Library.Application.Models.ViewModels;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Queries.BorrowingToDoList
{
    public class GetBorrowsByFilterQuery : IRequest<List<BorrowingRecordsViewModel>>
    {
        public GetBorrowsByFilterQuery() { }
    }
}
