using Library.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.ToDoList.Queries.StudentToDoList
{
    public class GetStudentByIdQuery : IRequest<StudentViewModel>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
