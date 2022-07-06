using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IZiyaretService
    {
        List<User> GetList();
        void ZiyaretciAdd(User ziyaret);
        User GetByID(int id);
        void ZiyaretciDelete(User ziyaret);
        void ZiyaretciUpdate(User ziyaret);
    }
}
