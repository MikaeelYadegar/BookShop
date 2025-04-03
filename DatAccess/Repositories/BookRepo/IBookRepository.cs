using DatAccess.Models;
using System.Linq.Expressions;
using System.Net.Mail;

namespace DatAccess.Repositories.BookRepo;

public interface IBookRepository
{
    IQueryable<Book> GetAll(Expression<Func<Book,bool>>where=null);
   Task<Book>GetByID(int id);
    Task Add(Book book);

    Task Update(Book book);
    Task Delete(Book book);
    Task Delete(int id);    
   Task< List <Comment>> GetCommentByID(int productId,int pageNumber,int pageSize);
    Task AddComment(Comment comment);
    Task DeleteComment(int commentId);
    Task<IEnumerable <Comment>> GetCommentByBookIdAsync(int productId,int pageNumber,int pageSize);
    Task<int> GetCommentCountByBookIdAsync(int productId);
}
