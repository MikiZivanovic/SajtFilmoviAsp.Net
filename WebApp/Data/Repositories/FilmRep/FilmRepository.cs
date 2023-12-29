using Microsoft.EntityFrameworkCore;
using WebApp.Data.ViewModels;
using WebApp.Models;

namespace WebApp.Data.Repositories.FilmRep
{
    public class FilmRepository : IFilmRepository
    {
        private readonly AppDbContext _context;
        public FilmRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Film t)
        {
            _context.Filmovi.Add(t);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Film> GetAll()
        {
            return _context.Filmovi.Include(f=>f.Bioskop).OrderBy(f => f.Ime).ToList();
        }

        public Film GetById(int id)
        {
            Film film = _context.Filmovi.Include(f => f.Bioskop).Include(f => f.Producent).
                Include(f => f.Glumci_Filmovi).ThenInclude(gf => gf.Glumac).Include(f=>f.Komentari_Filmovi).ThenInclude(kf=>kf.Komentar).FirstOrDefault(f => f.Id == id);
            return film;
        }

        public void Update(Film t)
        {
           _context.Filmovi.Update(t);
            _context.SaveChanges();
        }
    }
}
