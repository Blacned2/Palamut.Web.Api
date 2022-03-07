using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Model
{
    public class Siparis
    {
        [Key]
        public int SiparisID { get; set; }
        public int AliciID { get; set; }
        public int SaticiID { get; set; }
        public float ToplamFiyat { get; set; }
        
        [ForeignKey("AliciID")]
        public virtual Alici Alici { get; set; }
        [ForeignKey("SaticiID")]
        public virtual Satici Satici { get; set; }
    }
}
