using DatAccess.Models;
using DatAccess.Repositories.BookRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.BookService
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>>GetBooks()
        {
        return  await _bookRepository.GetAll().ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetBooksWithAuthore(Expression<Func<Book, bool>>where=null) 
        {
            return await _bookRepository.GetAll(where).Include(a=>a.Authore).ToListAsync();
        }
        public async Task<Book>GetBooksById(int id)
        {
            return await _bookRepository.GetByID(id);
        }   
        public async Task Update(Book book) 
        {
            await _bookRepository.Update(book);
        }
        public async Task Delete(Book book)
        {
            await _bookRepository.Delete(book);
        }
        public async Task CreateBook(Book book)
        {
            await _bookRepository.Add(book);
        }
    }
}
