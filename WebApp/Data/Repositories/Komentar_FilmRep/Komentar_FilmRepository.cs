using WebApp.Models;

namespace WebApp.Data.Repositories.Komentar_FilmRep
{
    

    public class Komentar_FilmRepository : IKomentar_FIlmRepository
    {
        private readonly AppDbContext _context;
        public Komentar_FilmRepository(AppDbContext context)
        {

            _context = context;

        }
        public void Add(Komentar_Film t)
        {
           _context.Komentari_Filmovi.Add(t);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Komentar_Film> GetAll()
        {
          return  _context.Komentari_Filmovi.ToList();
        }

        public Komentar_Film GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Komentar_Film t)
        {
            throw new NotImplementedException();
        }
    }
}
