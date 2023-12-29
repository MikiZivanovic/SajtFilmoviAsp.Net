namespace WebApp.Models
{
    public class Komentar_Film
    {
        public int KomentarId { get; set; }
        public Komentar Komentar { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
