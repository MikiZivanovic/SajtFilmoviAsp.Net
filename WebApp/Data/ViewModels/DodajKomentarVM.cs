using System.Globalization;

namespace WebApp.Data.ViewModels
{
    public class DodajKomentarVM
    {
        public string Text { get; set; }
        public string  UserId { get; set; }
        public int FilmId { get; set; }
        public int Rejting { get; set; }
    }
}
