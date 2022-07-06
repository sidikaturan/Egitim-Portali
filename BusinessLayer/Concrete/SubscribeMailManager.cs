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
    public class SubscribeMailManager : ISubscribeService
    {
        ISubscribeDal _subscribeDal;

        public SubscribeMailManager(ISubscribeDal subscribeDal)
        {
            this._subscribeDal = subscribeDal;
        }

        public void Add(SubscribeMail subscribe)
        {
            _subscribeDal.Insert(subscribe);
        }

        public void Delete(SubscribeMail subscribe)
        {
            _subscribeDal.Delete(subscribe);
        }

        public SubscribeMail GetByID(int id)
        {
            return _subscribeDal.Find(x => x.MailID == id);
        }

        public List<SubscribeMail> GetList()
        {
            return _subscribeDal.List();
        }
    }
}
