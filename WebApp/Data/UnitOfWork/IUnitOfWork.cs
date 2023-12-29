using WebApp.Data.Repositories.BioskopRep;
using WebApp.Data.Repositories.BiskopRep;
using WebApp.Data.Repositories.FilmRep;
using WebApp.Data.Repositories.Glumac_FilmRep;
using WebApp.Data.Repositories.Komentar_FilmRep;
using WebApp.Data.Repositories.KomentarRep;
using WebApp.Data.Repositories.ProducentRep;
using WebApp.Data.Services;

namespace WebApp.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IGlumacRepository IGlumacRepository { get; set; }
        public IProducentRepository IProducentRepository { get; set; }
        public IBioskopRepository IBioskopRepository { get; set; }
        public IFilmRepository IFilmRepository { get; set; }
        public IGlumac_FilmRepository IGlumac_FilmRepository { get; set; }
        public IKomentarRepository IKomentarRepository { get; set; }
        public IKomentar_FIlmRepository IKomentar_FIlmRepository { get; set; }
        public void SaveChanges();
    }
}
