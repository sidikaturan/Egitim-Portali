using BusinessLayer.Abstract;
using BusinessLayer.Hashing;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ZiyaretciManager : IZiyaretciService
    {
        IZiyaretService _ziyaretciService;

        public ZiyaretciManager(IZiyaretService ziyaretciService)
        {
            _ziyaretciService = ziyaretciService;
        }

        public bool ZiyaretciLogin(ZiyaretciLoginDto ziyaretciLoginDto)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var userNameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(ziyaretciLoginDto.ZiyaretciAdi));
                var writer = _ziyaretciService.GetList();
                foreach (var item in writer)
                {
                    if (HashingHelper.WriterVerifyPasswordHash(ziyaretciLoginDto.ZiyaretciPassword, item.ZiyaretciPasswordHash, item.ZiyaretciPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public bool ZiyaretciKayitKontrol(ZiyaretciLoginDto ziyaretciLoginDto)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var writer = _ziyaretciService.GetList();
                foreach (var item in writer)
                {
                    if (item.Mail == ziyaretciLoginDto.ZiyaretciAdi)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public void ZiyaretciKayit(string mail, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.WriterCreatePasswordHash(password,out passwordHash, out passwordSalt);
            var writer = new User
            {
                Mail = mail,
                ZiyaretciPasswordHash = passwordHash,
                ZiyaretciPasswordSalt = passwordSalt,
            };
            _ziyaretciService.ZiyaretciAdd(writer);
        }
    }
}
