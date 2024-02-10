using Library.Application.Abstractions;
using Library.Domain.Entities;
using Library.Infrastructure.DB.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.DB
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IAuthService _authService;
        public AppDbContext(DbContextOptions<AppDbContext> options, IAuthService authService)
            : base(options)
        {
            _authService = authService;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<PublisherAddress> PublisherAddresses { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BorrowingRecord> BorrowingRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration(_authService));
        }
    }
}
