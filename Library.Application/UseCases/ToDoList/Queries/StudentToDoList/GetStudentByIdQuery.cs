using Library.Application.Models.ViewModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.UseCases.ToDoList.Queries.StudentToDoList
{
    public class GetStudentByIdQuery : IRequest<StudentViewModel>
    {
        public GetStudentByIdQuery(Guid id)
        {
            Id = id;
        }
        [Required]
        public Guid Id { get; set; }
    }
}
