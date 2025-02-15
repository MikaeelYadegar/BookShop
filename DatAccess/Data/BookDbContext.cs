using DatAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DatAccess.Data;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Authore> Authores { get; set; }
}
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<BookDbContext>
{
    public BookDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=BookShop;Trusted_Connection=True;TrustServerCertificate=True;");

        return new BookDbContext(optionsBuilder.Options);
    }
}
 



