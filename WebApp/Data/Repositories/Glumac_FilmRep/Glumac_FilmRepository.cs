using WebApp.Models;

namespace WebApp.Data.Repositories.Glumac_FilmRep
{
    public class Glumac_FilmRepository : IGlumac_FilmRepository
    {
        private readonly AppDbContext _context;
        public Glumac_FilmRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Glumac_Film t)
        {
            _context.Glumci_Filmovi.Add(t);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var lista = GetAll();
            foreach (var item in lista)
            {
                if (item.FilmId == id) { 
                    _context.Glumci_Filmovi.Remove(item);
                    _context.SaveChanges();
                }


            }

           
        }

        public IEnumerable<Glumac_Film> GetAll()
        {
            return _context.Glumci_Filmovi.ToList();
        }

        public Glumac_Film GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Glumac_Film t)
        {
            _context.Glumci_Filmovi.Update(t);
            _context.SaveChanges();
        }
    }
}
