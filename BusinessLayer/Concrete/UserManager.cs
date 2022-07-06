using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager
    {

        Repository<User> repouser = new Repository<User>();
        //Tüm yazar Listesini Getirme
        public List<User> GetAll()
        {
            return repouser.List();
        }
        //Yeni Yazar ekleme işlemi
        public int AddUserBL(User p)
        {
            //Gönderilen değerlerin kontrolü
            if (p.UserName == "" | p.UserAboutShort == "" | p.UserTitle == "")
            {
                return -1;
            }
            return repouser.Insert(p);
        }
        //Kullanıcının id değerine göre edit sayfasına taşıma
        public User FindUser(int id)
        {
            return repouser.Find(x => x.UserID == id);
        }
        public int EditUser(User p)
        {
            User user = repouser.Find(x => x.UserID == p.UserID);
            user.UserAboutShort = p.UserAboutShort;
            user.UserName = p.UserName;
            user.UserImage = p.UserImage;
            user.UserAbout = p.UserAbout;
            user.UserTitle = p.UserTitle;
            user.Mail = p.Mail;
            user.UserNo = p.UserNo;
            return repouser.Update(user);

        }
    }
}
