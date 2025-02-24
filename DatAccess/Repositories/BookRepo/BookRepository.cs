using DatAccess.Data;
using DatAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DatAccess.Repositories.BookRepo;

public class BookRepository : IBookRepository
{
    private readonly BookDbContext _context;
    public BookRepository(BookDbContext context)
    {
        _context = context;
    }
    public async Task Add(Book book)
    {
          _context.Books.Add(book);
        await _context.SaveChangesAsync();  
    }

    public async Task Delete(Book book)
    {
      _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
       var book= await GetByID(id);
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();  
    }

    public IQueryable<Book> GetAll(Expression<Func<Book, bool>> where = null)
    {
    var books=_context.Books.AsQueryable();
        if(where!=null)
        {
            books=books.Where(where);
        }
        return books;
    }

    public async Task<Book> GetByID(int id)
    {
        return await _context.Books.Include(a=>a.Authore).FirstOrDefaultAsync(x => x.Id == id);    
    }

    public async Task Update(Book book)
    {
       _context.Books.Update(book);
        await _context.SaveChangesAsync(); 
    }
}
