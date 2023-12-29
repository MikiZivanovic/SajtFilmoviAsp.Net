using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Glumac
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Url slike je obavezan")]
        public string UrlSlike { get; set; }

        [Required(ErrorMessage = "Ime i prezime su obavezni")]
        [StringLength(50,MinimumLength =7,ErrorMessage ="Ime i prezime ne smeju zajedno biti manji od 7 ni veci od 50 karaktera")]
        public string PunoIme { get; set; }
        [Required(ErrorMessage = "Biografija je obavezna")]
        public string Biografija { get; set; }

        //Veze
        public List<Glumac_Film> Glumci_Filmovi { get; set; }
    }
}
