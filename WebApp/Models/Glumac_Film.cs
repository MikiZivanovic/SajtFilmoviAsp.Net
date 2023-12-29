namespace WebApp.Models
{
    public class Glumac_Film
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int GlumacId { get; set; }
        public Glumac Glumac { get; set; }
    }
}
