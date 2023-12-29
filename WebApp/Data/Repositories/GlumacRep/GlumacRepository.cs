using WebApp.Models;

namespace WebApp.Data.Services
{
    public class GlumacRepository : IGlumacRepository
    {
        private readonly AppDbContext _context;
        public GlumacRepository(AppDbContext context)
        {
                _context = context;
        }
        public void Add(Glumac glumac)
        {
            _context.Glumci.Add(glumac);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var glumacZaBrisanje = GetById(id);
            _context.Glumci.Remove(glumacZaBrisanje) ;
            _context.SaveChanges();
        }

        public IEnumerable<Glumac> GetAll()
        {
            var listaGlumaca = _context.Glumci.ToList();
            return listaGlumaca;
        }

        public Glumac GetById(int id)
        {
            return _context.Glumci.FirstOrDefault(g => g.Id == id);
        }

        public void Update( Glumac glumac)
        {

            _context.Glumci.Update(glumac);
           
            _context.SaveChanges();
        }
    }
}
