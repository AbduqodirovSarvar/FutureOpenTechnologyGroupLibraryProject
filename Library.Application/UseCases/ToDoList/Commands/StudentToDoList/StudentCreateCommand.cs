using Library.Application.Models.ViewModels;
using MediatR;

namespace Library.Application.UseCases.ToDoList.Commands.StudentToDoList
{
    public class StudentCreateCommand : IRequest<StudentViewModel>
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string RegionName { get; set; } = null!;
        public string? Block { get; set; }
        public string Street { get; set; } = null!;
        public int HomeNumber { get; set; }
        public int? ApartmentNumber { get; set; }
    }
}
