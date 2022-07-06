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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogdal;
        Repository<Blog> repoblog = new Repository<Blog>();

        public BlogManager(IBlogDal blogdal)
        {
            _blogdal = blogdal;
        }

        public void Add(Blog bloglar)
        {
            _blogdal.Insert(bloglar);
        }

        public List<Blog> BlogListele()
        {
            return _blogdal.List();
        }
        
        public void Delete(Blog bloglar)
        {
            _blogdal.Delete(bloglar);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return repoblog.List(x => x.CategoryID == id);
        }
        public List<Blog> GetBlogByBlog(int id)
        {
            return repoblog.List(x => x.BlogID == id);
        }
        public List<Blog> GetBlogByUser(string p)
        {
            return repoblog.List(x => x.OlusturanKisi == p);
        }

        public Blog GetByID(int id)
        {
            return _blogdal.Find(x => x.BlogID == id);
        }

        public void Update(Blog bloglar)
        {
            _blogdal.Update(bloglar);
        }

        public List<Blog> BlogFiltrele(string p)
        {
           return _blogdal.List(x => x.BlogTitle.Contains(p));
        }

      
    }
}
