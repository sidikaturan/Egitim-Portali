using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Icerik content)
        {
           _contentDal.Insert(content);
        }

        public void ContentDelete(Icerik content)
        {
            _contentDal.Delete(content);
        }

        public List<Icerik> ContentList()
        {
            return _contentDal.List(); 
        }

        public void ContentUpdate(Icerik content)
        {
            _contentDal.Update(content);
        }

        public Icerik GetByID(int id)
        {
            return _contentDal.Find(x => x.IcerikID == id);
        }

        public List<Icerik> IcerikByBlog(int id)
        {
            return _contentDal.List(x => x.BlogID == id);
        }
    }
}
