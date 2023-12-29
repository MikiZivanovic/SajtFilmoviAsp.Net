using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data.Repositories.KomentarRep
{
    public class KomentarRepository : IKomentarRepository
    {
        private readonly AppDbContext _context;
        public KomentarRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Komentar t)
        {
            _context.Komentari.Add(t);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
           Komentar k = GetById(id);
           _context.Komentari.Remove(k);
            _context.SaveChanges();
        }

        public IEnumerable<Komentar> GetAll()
        {
            return _context.Komentari.Include(k=>k.User).ToList();
        }

        public Komentar GetById(int id)
        {
            return _context.Komentari.Include(k => k.User).FirstOrDefault(k => k.KomentarId == id);
        }

        public void Update(Komentar t)
        {
            _context.Komentari.Update(t);
            _context.SaveChanges();
        }
    }
}
