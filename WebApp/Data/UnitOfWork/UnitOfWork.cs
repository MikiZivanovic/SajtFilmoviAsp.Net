using WebApp.Data.Repositories.BioskopRep;
using WebApp.Data.Repositories.BiskopRep;
using WebApp.Data.Repositories.FilmRep;
using WebApp.Data.Repositories.Glumac_FilmRep;
using WebApp.Data.Repositories.Komentar_FilmRep;
using WebApp.Data.Repositories.KomentarRep;
using WebApp.Data.Repositories.Producent;
using WebApp.Data.Repositories.ProducentRep;
using WebApp.Data.Services;

namespace WebApp.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            IGlumacRepository = new GlumacRepository(context);
            IProducentRepository = new ProducentRepository(context);
            IBioskopRepository = new BioskopRepository(context);
            IFilmRepository = new FilmRepository(context);
            IGlumac_FilmRepository = new Glumac_FilmRepository(context);
            IKomentarRepository = new KomentarRepository(context);
            IKomentar_FIlmRepository = new Komentar_FilmRepository(context);

        }
        public IGlumacRepository IGlumacRepository { get; set; }
        
        public IBioskopRepository IBioskopRepository { get ; set ; }
        public IProducentRepository IProducentRepository { get ; set ; }
        public IFilmRepository IFilmRepository { get; set ; }
        public IGlumac_FilmRepository IGlumac_FilmRepository { get ; set ; }
        public IKomentarRepository IKomentarRepository { get; set; }
        public IKomentar_FIlmRepository IKomentar_FIlmRepository { get; set; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
