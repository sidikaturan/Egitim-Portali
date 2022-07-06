using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Icerik> ContentList();
        Icerik GetByID(int id);
        List<Icerik> IcerikByBlog(int id);
        void ContentAdd(Icerik content);
        void ContentUpdate(Icerik content);
        void ContentDelete(Icerik content);
    }
}
