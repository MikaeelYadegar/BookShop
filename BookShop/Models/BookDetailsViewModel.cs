using DatAccess.Models;

namespace BookShop.Models
{
    public class BookDetailsViewModel
    {
        public Book Book { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment NewComment { get; set; }=new Comment();
    }
}
