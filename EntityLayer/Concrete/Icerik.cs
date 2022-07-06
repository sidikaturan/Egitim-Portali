using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Icerik
    {
        [Key]
        public int IcerikID { get; set; }
        public string IcerikAciklamasi { get; set; }
        public int TipID { get; set; }
        public virtual IcerikTipi IcerikTipi { get; set; }
        public int BlogID { get; set; }
        public virtual Blog Blogs { get; set; }
    }
}
