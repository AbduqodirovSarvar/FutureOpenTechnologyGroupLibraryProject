using Library.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
