using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void ChangeCommentStatus(Comment comment)
        {
            
            if(comment.CommentStatus == true)
            {
                comment.CommentStatus = false;
            }
            _commentDal.Update(comment);
        }

        public void CommentAdd(Comment comment)
        {
            comment.CommentStatus = true;
            _commentDal.Insert(comment);
        }

        public List<Comment> CommentByBlog(int id)
        {
            return _commentDal.List(x => x.BlogID == id);
        }

        public List<Comment> CommentList()
        {
            return _commentDal.List();
        }

        public Comment GetByID(int id)
        {
            return _commentDal.Find(x => x.CommentID == id);
        }
        public List<Comment> YorumFiltrele(string p)
        {
            return _commentDal.List(x => x.CommentText.Contains(p));
        }
    }

}
