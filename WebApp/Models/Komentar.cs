using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Komentar
    {
        [Key]
        public int KomentarId { get; set; }
        public string Text { get; set; }
        public DateTime Vreme { get; set; }
        public int Rejting { get; set; }
        public bool Odobren { get; set; } 

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicatonUser User { get; set; }

        public List<Komentar_Film> Komentar_Film { get; set; }
    }
}
