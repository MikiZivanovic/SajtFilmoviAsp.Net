using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Data;

namespace WebApp.Models
{
    public class Film
    {
        public int Id { get; set; }

        public string Ime { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public string UrlSlike { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public KategorijaFilma KategorijaFilma { get; set; }

        //Veze

        public List<Glumac_Film> Glumci_Filmovi { get; set; }
        public List<Komentar_Film> Komentari_Filmovi { get; set; }
        //Bioskop
        public int BioskopId { get; set; }
        [ForeignKey("BioskopId")]
        public Bioskop Bioskop { get; set; }

        //Producent
        public int ProducentId { get; set; }
        [ForeignKey("ProducentId")]
        public Producent Producent { get; set; }

    }
}
