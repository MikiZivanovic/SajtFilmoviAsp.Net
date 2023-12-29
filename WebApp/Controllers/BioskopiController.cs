using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Data.UnitOfWork;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BioskopiController : Controller
    {
        private readonly IUnitOfWork _context;

        public BioskopiController(IUnitOfWork context)
        {

            _context = context;

        }
        public IActionResult Index()
        {
            var listaBioskopa = _context.IBioskopRepository.GetAll();
            return View(listaBioskopa);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Bioskop bioskop)
        {
            //if (!ModelState.IsValid)
            //{

            //    return View(bioskop);
            //}

            _context.IBioskopRepository.Add(bioskop);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var bioskopDetalji = _context.IBioskopRepository.GetById(id);
            if (bioskopDetalji == null)
            {
                return View("NotFound");
            }
            return View(bioskopDetalji);
        }
        public IActionResult Edit(int id)
        {
            var bioskopEditovanje = _context.IBioskopRepository.GetById(id);
            if (bioskopEditovanje == null)
            {
                return View("NotFound");
            }
            return View(bioskopEditovanje);
        }
        [HttpPost]
        public IActionResult Edit(Bioskop bioskop)
        {
            //if (!ModelState.IsValid)
            //{

            //    return View(bioskop);
            //}

            _context.IBioskopRepository.Update(bioskop);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var bioskopDeletovanja = _context.IBioskopRepository.GetById(id);
            if (bioskopDeletovanja == null)
            {
                return View("NotFound");
            }
            return View(bioskopDeletovanja);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            //if (!ModelState.IsValid)
            //{

            //    return View();
            //}

            _context.IBioskopRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
