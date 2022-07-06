using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ZiyaretManager: IZiyaretService
    {
        EfUserDal _ziyaretDal;

        public ZiyaretManager(EfUserDal ziyaretDal)
        {
            _ziyaretDal = ziyaretDal;
        }

        public List<User> GetList()
        {
            return _ziyaretDal.List();
        }

        public void ZiyaretciAdd(User ziyaretci)
        {
            _ziyaretDal.Insert(ziyaretci);
        }

        public User GetByID(int id)
        {
            return _ziyaretDal.Find(x => x.UserID == id);
        }
       
        public User GetByMailID(string p)
        {
            return _ziyaretDal.Find(x => x.Mail == p);
        }
        public void ZiyaretciDelete(User ziyaretci)
        {
            _ziyaretDal.Delete(ziyaretci);
        }

        public void ZiyaretciUpdate(User ziyaretci)
        {
            _ziyaretDal.Update(ziyaretci);
        }
    }
}
