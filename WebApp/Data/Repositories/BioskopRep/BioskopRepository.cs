



using WebApp.Data.Repositories.BiskopRep;

namespace WebApp.Data.Repositories.BioskopRep
{
    public class BioskopRepository : IBioskopRepository
    {
        private readonly AppDbContext _context;

        public BioskopRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(WebApp.Models.Bioskop t)
        {
            _context.Bioskopi.Add(t);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            WebApp.Models.Bioskop bioskopZaBrisanje = _context.Bioskopi.FirstOrDefault(p => p.Id == id);
            _context.Bioskopi.Remove(bioskopZaBrisanje);
            _context.SaveChanges();
        }

        public IEnumerable<WebApp.Models.Bioskop> GetAll()
        {
            return _context.Bioskopi.ToList();
        }

        public WebApp.Models.Bioskop GetById(int id)
        {
            var bioskop = _context.Bioskopi.FirstOrDefault(p => p.Id == id);
            return bioskop;
        }

        public void Update(WebApp.Models.Bioskop t)
        {
            
            _context.Bioskopi.Update(t);
            _context.SaveChanges();
        }
    }
}
