using DatAccess.Data;
using DatAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Repositories.CommentRepo
{
    public class CommentService:ICommentService
    {
        private readonly BookDbContext _context;
        public CommentService(BookDbContext context)
        {
            _context = context;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public List<Comment> GetCommentByBookId(int bookId)
        {
            return _context.Comments.Where(c=>c.Id == bookId).ToList();
        }
    }
}
