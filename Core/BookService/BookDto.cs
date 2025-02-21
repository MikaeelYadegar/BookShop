using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.BookService
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IFormFile? Img { get; set; }
        public bool IsAvail { get; set; }
        public bool ShowHomePage { get; set; }
        public string?ImgName { get; set; }

        public int AuthoreId { get; set; }
    }
}
