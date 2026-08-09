using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Entities;

namespace MyFirstApi.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<LibraryMember> LibraryMembers { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Loan> Loans { get; set; }
}