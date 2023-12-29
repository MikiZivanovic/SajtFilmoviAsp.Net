using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.UnitOfWork;
using WebApp.Data.ViewModels;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class FilmoviController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicatonUser> _userManager;
        public FilmoviController(IUnitOfWork context, UserManager<ApplicatonUser> userManager)
        {
            _context = context;
            _userManager= userManager;
        }
        public IActionResult Index()
        {
            var listafilmova = _context.IFilmRepository.GetAll();
            return View(listafilmova);
        }
        public IActionResult Pretraga(string pretragaStringa)
        {
            var resultatPretrage = _context.IFilmRepository.GetAll();
            if (!string.IsNullOrEmpty(pretragaStringa))
            {

                resultatPretrage = resultatPretrage.Where(f => f.Opis.Contains(pretragaStringa) || f.Ime.Contains(pretragaStringa)).ToList();
                return View("Index", resultatPretrage);

            }
            return View("Index", resultatPretrage);
        }

            public IActionResult Details(int id)
        {
            var film = _context.IFilmRepository.GetById(id);
            return View(film);


        }
        public IActionResult Create()
        {
            DodajFilmVM dodajFilmVM = new DodajFilmVM();

            ViewBag.Glumci = new SelectList(_context.IGlumacRepository.GetAll(), "Id", "PunoIme");
            ViewBag.Bioskopi = new SelectList(_context.IBioskopRepository.GetAll(), "Id", "Ime");
            ViewBag.Producenti = new SelectList(_context.IProducentRepository.GetAll(), "Id", "PunoIme");

            return View(dodajFilmVM);


        }
        [HttpPost]
        public IActionResult Create(DodajFilmVM noviFilm)
        {
            if (!ModelState.IsValid) {
                ViewBag.Glumci = new SelectList(_context.IGlumacRepository.GetAll(), "Id", "PunoIme");
                ViewBag.Bioskopi = new SelectList(_context.IBioskopRepository.GetAll(), "Id", "Ime");
                ViewBag.Producenti = new SelectList(_context.IProducentRepository.GetAll(), "Id", "PunoIme");
                return View(noviFilm);
            }
            

            
            
            Film film = new Film()
            {
                Ime = noviFilm.Ime,
                Opis = noviFilm.Opis,
                Cena = noviFilm.Cena,
                UrlSlike= noviFilm.UrlSlike,
                DatumPocetka = noviFilm.DatumPocetka,
                DatumZavrsetka = noviFilm.DatumZavrsetka,
                KategorijaFilma = noviFilm.KategorijaFilma,
                ProducentId= noviFilm.ProducentId,
                BioskopId= noviFilm.BioskopId


            };
            _context.IFilmRepository.Add(film);
           

            foreach(int id in noviFilm.GlumciIdijevi)
            {
                Glumac_Film film_Glumac = new Glumac_Film();
                film_Glumac.GlumacId = id;
                film_Glumac.FilmId = _context.IFilmRepository.GetAll().ToList().FirstOrDefault(f=>f.Ime==noviFilm.Ime).Id;

                _context.IGlumac_FilmRepository.Add(film_Glumac);
            }
             return RedirectToAction("Index");
            
        }
        public IActionResult Edit(int id)
        {
            Film film = _context.IFilmRepository.GetById(id);

            DodajFilmVM dodajFilmVM = new DodajFilmVM() {
                Id = film.Id,
                Ime = film.Ime,
                Opis = film.Opis,
                Cena = film.Cena,
                UrlSlike = film.UrlSlike,
                DatumPocetka = film.DatumPocetka,
                DatumZavrsetka = film.DatumZavrsetka,
                KategorijaFilma = film.KategorijaFilma,
                ProducentId = film.ProducentId,
                BioskopId = film.BioskopId,
                GlumciIdijevi = film.Glumci_Filmovi.Select(g => g.GlumacId).ToList()


            };

            ViewBag.Glumci = new SelectList(_context.IGlumacRepository.GetAll(), "Id", "PunoIme");
            ViewBag.Bioskopi = new SelectList(_context.IBioskopRepository.GetAll(), "Id", "Ime");
            ViewBag.Producenti = new SelectList(_context.IProducentRepository.GetAll(), "Id", "PunoIme");

            return View(dodajFilmVM);


        }
        [HttpPost]
        public IActionResult Edit(DodajFilmVM noviFilm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Glumci = new SelectList(_context.IGlumacRepository.GetAll(), "Id", "PunoIme");
                ViewBag.Bioskopi = new SelectList(_context.IBioskopRepository.GetAll(), "Id", "Ime");
                ViewBag.Producenti = new SelectList(_context.IProducentRepository.GetAll(), "Id", "PunoIme");
                return View(noviFilm);
            }




            Film film = new Film()
            { 
                Id=noviFilm.Id,
                Ime = noviFilm.Ime,
                Opis = noviFilm.Opis,
                Cena = noviFilm.Cena,
                UrlSlike = noviFilm.UrlSlike,
                DatumPocetka = noviFilm.DatumPocetka,
                DatumZavrsetka = noviFilm.DatumZavrsetka,
                KategorijaFilma = noviFilm.KategorijaFilma,
                ProducentId = noviFilm.ProducentId,
                BioskopId = noviFilm.BioskopId


            };
            _context.IFilmRepository.Update(film);

            
             _context.IGlumac_FilmRepository.Delete(noviFilm.Id);
                
            
           



            foreach (int id in noviFilm.GlumciIdijevi)
            {
                Glumac_Film film_Glumac = new Glumac_Film();
                film_Glumac.GlumacId = id;
                film_Glumac.FilmId = noviFilm.Id;
                _context.IGlumac_FilmRepository.Add(film_Glumac);
            }
            return RedirectToAction("Index");

        }
        public IActionResult odobriKomentar(int id ) {
            _context.IKomentarRepository.GetById(id).Odobren = true ;
            _context.SaveChanges();
            return RedirectToAction("Index");
           
           
        }

        public IActionResult dodajKomentar(int id) { 
                DodajKomentarVM vm = new DodajKomentarVM();
                vm.UserId = _userManager.GetUserId(User);
                 vm.FilmId = id;
                return View(vm);
        }
        [HttpPost]
        public IActionResult dodajKomentar(DodajKomentarVM vm)
        {
            Komentar k = new Komentar();
            k.Text = vm.Text;
            k.UserId = vm.UserId;
            k.Rejting = vm.Rejting;
            k.Vreme = DateTime.Now;
            k.Odobren = false;
            
            _context.IKomentarRepository.Add(k);
            Komentar_Film km = new Komentar_Film();
            km.KomentarId = _context.IKomentarRepository.GetAll().FirstOrDefault(k => k.UserId == vm.UserId && k.Text == vm.Text ).KomentarId;
            km.FilmId = vm.FilmId;

            _context.IKomentar_FIlmRepository.Add(km);

            return RedirectToAction("Index");
        }
    }
}
