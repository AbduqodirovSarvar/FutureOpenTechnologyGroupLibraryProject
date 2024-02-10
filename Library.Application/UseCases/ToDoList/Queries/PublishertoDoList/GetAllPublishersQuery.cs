using Library.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Queries.PublishertoDoList
{
    public class GetAllPublishersQuery : IRequest<List<PublisherViewModel>>
    {
        public GetAllPublishersQuery() { }
    }
}
