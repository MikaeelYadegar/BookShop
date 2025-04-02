using DatAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatAccess.Repositories.CommentRepo
{
    public interface ICommentService
    {
        List<Comment> GetCommentByBookId(int bookId);
        void AddComment(Comment comment);
    }
}
