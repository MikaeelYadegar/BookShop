using DatAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DatAccess.Data;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Authore> Authores { get; set; }
}
