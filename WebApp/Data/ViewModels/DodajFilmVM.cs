using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;

namespace WebApp.Data.ViewModels
{
    public class DodajFilmVM
    {


        public int Id { get; set; }
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Opis je obavezan")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Cena je obavezna")]
        public double Cena { get; set; }
        [Required(ErrorMessage = "UrlSlike je obavezan")]
        public string UrlSlike { get; set; }
        [Required(ErrorMessage = "DatumPocetka je obavezan")]
        public DateTime DatumPocetka { get; set; }
        [Required(ErrorMessage = "DatumZavrsetka je obavezan")]
        public DateTime DatumZavrsetka { get; set; }
        [Required(ErrorMessage = "Kategorijafilma je obavezna")]
        public KategorijaFilma KategorijaFilma { get; set; }
        [Required(ErrorMessage = "Idijevi glumaca su obavezni")]
        public List<int> GlumciIdijevi { get; set; }
        
        [Required(ErrorMessage = "Id bioskopa je obavezan")]
        public int BioskopId { get; set; }

        [Required(ErrorMessage = "Id producenta je obavezan")]
        public int ProducentId { get; set; }
        
    }
}
