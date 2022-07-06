using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void Add(Blog bloglar);
        void Update(Blog bloglar);
        void Delete(Blog bloglar);
        List<Blog> BlogListele();
        List<Blog> BlogFiltrele(string p);
        Blog GetByID(int id);
        List<Blog> GetBlogByUser(string p);
        List<Blog> GetBlogByCategory(int id);
    }
}
