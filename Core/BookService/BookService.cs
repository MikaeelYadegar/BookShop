using Core.FileUpload;
using DatAccess.Models;
using DatAccess.Repositories.BookRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks; 
namespace Core.BookService
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IFileUploadService _fileUploadService;
        public BookService(IBookRepository bookRepository,IFileUploadService fileUploadService)
        {
            _bookRepository = bookRepository;
            _fileUploadService = fileUploadService;
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
        public async Task CreateBook(BookDto bookdto)
        {
            var book = new Book()
            {
            AuthoreId=bookdto.AuthoreId,
            Price=bookdto.Price,
            Description=bookdto.Description,
            Title=bookdto.Title,
            };
            book.Img = await _fileUploadService.UploadFileAsync(bookdto.Img);

            await _bookRepository.Add(book);
        }
    }
}
