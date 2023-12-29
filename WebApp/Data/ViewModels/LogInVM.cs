using System.ComponentModel.DataAnnotations;

namespace WebApp.Data.ViewModels
{
    public class LogInVM
    {

        
        [Required(ErrorMessage = "Imejl adreasa je obavezna")]
        public string ImejlAdresa { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifra { get; set; }
    }
}
