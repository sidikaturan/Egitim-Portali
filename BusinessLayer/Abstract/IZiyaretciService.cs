using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IZiyaretciService
    {
        bool ZiyaretciLogin(ZiyaretciLoginDto ziyaretciLoginDto);
        bool ZiyaretciKayitKontrol(ZiyaretciLoginDto ziyaretciLoginDto);
        void ZiyaretciKayit(string mail, string password);
    }
}
