
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> CommentList();
        Comment GetByID(int id);
        List<Comment> CommentByBlog(int id);
        void CommentAdd(Comment comment);
        void ChangeCommentStatus(Comment comment);
        
    }
}
