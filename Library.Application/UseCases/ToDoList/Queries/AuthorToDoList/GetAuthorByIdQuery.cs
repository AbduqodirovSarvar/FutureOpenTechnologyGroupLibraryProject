using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Queries.AuthorToDoList
{
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public GetAuthorByIdQuery(Guid id)
        {
            Id = id;
        }
        [Required]
        public Guid Id { get; set; }
    }
}
