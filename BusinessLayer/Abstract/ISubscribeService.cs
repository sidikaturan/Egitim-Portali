using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISubscribeService
    {
        void Add(SubscribeMail subscribe);
        void Delete(SubscribeMail subscribe);
        SubscribeMail GetByID(int id);
        List<SubscribeMail> GetList();
    }
}
