using DatAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DatAccess.Data;

public class BookDbContext : IdentityDbContext<User,Role,int>
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Authore> Authores { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItems> BasketItems { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Story> Stories { get; set; }
    public DbSet<MessageChat> MessageChats { get; set; }
    public DbSet<DiscountCode> DiscountCodes { get; set; }
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
 



