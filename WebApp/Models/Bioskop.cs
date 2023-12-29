using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Bioskop
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "URlLoga slike je obavezan")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Naziv bioskopa je obavezan")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Ime i prezime ne smeju zajedno biti manji od 7 ni veci od 50 karaktera")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Opis bioskopa je obavezan")]
        public string Opis { get; set; }

        //Veza 
        public List<Film> Filmovi { get; set; }
    }
}
