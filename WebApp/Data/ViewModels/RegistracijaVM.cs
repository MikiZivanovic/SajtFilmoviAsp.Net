using System.ComponentModel.DataAnnotations;

namespace WebApp.Data.ViewModels
{
    public class RegistracijaVM
    {
        [Required(ErrorMessage = "Ime i prezime su obavezni")]
        public string PunoIme { get; set; }
        [Required(ErrorMessage = "Imejl adreasa je obavezna")]
        public string ImejlAdresa { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifra { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        [Compare("Sifra",ErrorMessage ="Niste uneli istu sifru za potvdru sifre")]
        public string PotvrdaSifre { get; set; }

        [Required(ErrorMessage = "Godine su obavezne")]
        public int Godine { get; set; }

        [Required(ErrorMessage = "Url slike je obavezan")]
        public string UrlSlike { get; set; }
    }
}
