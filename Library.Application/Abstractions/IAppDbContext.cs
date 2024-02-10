using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Abstractions
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<StudentAddress> StudentAddresses { get; set; }
        DbSet<Address> Addresss { get; set; }
        DbSet<PublisherAddress> PublisherAddresses { get; set; }
        DbSet<Publisher> Publishers {  get; set; }
        DbSet<ContactInformation> ContactInformations { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<BookAuthor> BookAuthors { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
