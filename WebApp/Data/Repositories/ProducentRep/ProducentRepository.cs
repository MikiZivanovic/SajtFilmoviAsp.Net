

using WebApp.Data.Repositories.ProducentRep;

namespace WebApp.Data.Repositories.Producent
{
    public class ProducentRepository : IProducentRepository
    {
        private readonly AppDbContext _context;

        public ProducentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(WebApp.Models.Producent t)
        {
            _context.Producenti.Add(t);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            WebApp.Models.Producent producentZaBrisanje = _context.Producenti.FirstOrDefault(p => p.Id == id);
            _context.Producenti.Remove(producentZaBrisanje);
            _context.SaveChanges();
        }

        public IEnumerable<WebApp.Models.Producent> GetAll()
        {
            return _context.Producenti.ToList();
        }

        public WebApp.Models.Producent GetById(int id)
        {
            var producent = _context.Producenti.FirstOrDefault(p => p.Id == id);
            return producent;
        }

        public void Update(WebApp.Models.Producent t)
        {
            
            _context.Producenti.Update(t);
            _context.SaveChanges();
        }
    }
}
