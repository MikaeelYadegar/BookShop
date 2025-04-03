using DatAccess.Data;
using DatAccess.Models;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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

    public async Task AddComment(Comment comment)
    {
        Debug.WriteLine($"ProductIdهنگام ذخیره در دیتابیس فرم :{comment.ProductId}");
        if (comment.ProductId == 0)
        
            throw new Exception("productid مقدار ندارد");
        
       await _context.Comments.AddAsync(comment);
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

    public async Task DeleteComment(int commentId)
    {
       var comment=await _context.Comments.FindAsync(commentId);
        if(comment!=null)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
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

    public async Task<IEnumerable<Comment>> GetCommentByBookIdAsync(int productId, int pageNumber, int pageSize)
    {
         return await _context.Comments
                    .Where(c=>c.ProductId== productId)
                    .OrderBy(c=>c.CreatedAt)
                    .Skip((pageNumber-1)*pageSize)
                    .Take(pageSize)
                    .ToListAsync();
    }

    public async Task<List<Comment>> GetCommentByID(int productId,int pageNumber,int pagSize)
    {
        return await _context.Comments.Where(c => c.ProductId == productId)
                                        .OrderByDescending(c => c.CreatedAt)
                                        .Skip((pageNumber-1)*pagSize)
                                        .Take(pagSize)
                                      
                                        .ToListAsync();
                        
            
    }
    public async Task <int> GetCommentCount(int productId)
    {
        return await _context.Comments.CountAsync(c=>c.ProductId == productId);
    }

    public async Task<int> GetCommentCountByBookIdAsync(int productId)
    {
       return await _context.Comments
            .Where(c=>c.ProductId== productId).CountAsync();
    }

    public async Task Update(Book book)
    {
       _context.Books.Update(book);
        await _context.SaveChangesAsync(); 
    }

 

}
