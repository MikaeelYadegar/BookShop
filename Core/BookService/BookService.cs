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
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Net;
namespace Core.BookService
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IFileUploadService _fileUploadService;
        public BookService(IBookRepository bookRepository, IFileUploadService fileUploadService)
        {
            _bookRepository = bookRepository;
            _fileUploadService = fileUploadService;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.GetAll().ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetBooksWithAuthore(Expression<Func<Book, bool>> where = null)
        {
            return await _bookRepository.GetAll(where).Include(a => a.Authore).ToListAsync();
        }
        public async Task<Book> GetBooksById(int id)
        {
            return await _bookRepository.GetByID(id);
        }
        public async Task Update(BookDto bookDto)
        {
            var book = await GetBooksById(bookDto.Id);
            book.Title = bookDto.Title;
            book.Price = bookDto.Price;
            book.Description = bookDto.Description;
            book.AuthoreId = bookDto.AuthoreId;
            book.IsAvail = bookDto.IsAvail;
            book.ShowHomePage = bookDto.ShowHomePage;
            book.Created = DateTime.Now;

            if (bookDto.Img != null)
            {
                book.Img = await _fileUploadService.UploadFileAsync(bookDto.Img);
            }
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
                AuthoreId = bookdto.AuthoreId,
                Price = bookdto.Price,
                Description = bookdto.Description,
                Title = bookdto.Title,
                IsAvail = bookdto.IsAvail,
                ShowHomePage = bookdto.ShowHomePage,
                Created = DateTime.Now,
            };
            book.Img = await _fileUploadService.UploadFileAsync(bookdto.Img);

            await _bookRepository.Add(book);
        }

        public async Task<BookDto> GetBookDtoById(int id)
        {
            var book = await _bookRepository.GetByID(id);
            var bookDto = new BookDto()
            {
                Id = id,
                Title = book.Title,
                Price = book.Price,
                Description = book.Description,
                AuthoreId = book.AuthoreId,
                ImgName = book.Img,
                IsAvail = book.IsAvail,
                ShowHomePage = book.ShowHomePage,
            };
            return bookDto;
        }


        public async Task<PageBookDto> GetBookPageInation(int page, int pagesize, string search)
        {
            var books = _bookRepository.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                books = books.Where(a => a.Title.Contains(search) || a.Description.Contains(search) || a.Authore.Name.Contains(search));
            }
            int totalcount = books.Count();
            int totalpage = (int)Math.Ceiling((double)totalcount / pagesize);

            books = books.Skip((page - 1) * pagesize).Take(pagesize);
            books = books.Include(a => a.Authore);
            var bookDtos = await books.Select(s => new BookDto()
            {
                Id = s.Id,
                ImgName = s.Img,
                Price = s.Price,
                Title = s.Title,
                Description = s.Description,
                AuthoreName = s.Authore.Name,
                AuthoreId = s.AuthoreId,
            }).ToListAsync();
            var result = new PageBookDto()
            {
                Items = bookDtos,
                Page = page,
                TotalPage = totalpage,
                
            };
            return result;
        }
        public async Task<List<Comment>> GetCommentByID(int productId,int pageNumber=1,int pageSize=5)
        {
          // return await _bookRepository.GetCommentByID(productId);
           return await _bookRepository.GetCommentByID(productId,pageNumber,pageSize);
 
        }

        public async Task AddComment(Comment comment)
        {
         if(comment.ProductId==0)
            {
                throw new Exception("ProductId مقدار ندارد");
            }
         
            await _bookRepository.AddComment(comment);
       
        }
        public async Task DeleteComment(int commentId)
        {
            await _bookRepository.DeleteComment(commentId);
        }
        public async Task<int> GetCommentCountByBookIdAsync(int productId)
        {
            return await _bookRepository.GetCommentCountByBookIdAsync(productId);   
        }

    }
}
