using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class IcerikTipi
    {
        [Key]
        public int TipID { get; set; }
        public string Metin { get; set; }
        public ICollection<Icerik> Iceriks { get; set; }

    }
}
