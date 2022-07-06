using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(500)]
        public string UserImage { get; set; }

        [StringLength(250)]
        public string UserAbout { get; set; }

        [StringLength(100)]      
        public string  UserTitle { get; set; }

        [StringLength(100)]
        public string UserAboutShort { get; set; }

        [StringLength(300)]
        public string Mail { get; set; }
        public byte[] ZiyaretciPasswordHash { get; set; }
        public byte[] ZiyaretciPasswordSalt { get; set; }

        [StringLength(20)]
        public string UserNo { get; set; }

        public ICollection<Blog> Blogs { get; set; }

    }
}
