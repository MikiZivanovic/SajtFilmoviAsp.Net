using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Data.UnitOfWork;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProducentiController : Controller
    {
        private readonly IUnitOfWork _context;
       
        public ProducentiController(IUnitOfWork context) {
            
               _context = context;
        
        }
        public IActionResult Index()
        {
            var listaProducenata = _context.IProducentRepository.GetAll(); 
            return View(listaProducenata);
        }
       
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Producent producent)
        {
            //if (!ModelState.IsValid) {

            //    return View(producent);
            //}

            _context.IProducentRepository.Add(producent);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var producentDetalji = _context.IProducentRepository.GetById(id);
            if (producentDetalji == null)
            {
                return View("NotFound");
            }
            return View(producentDetalji);
        }
        public IActionResult Edit(int id)
        {
            var producentEditovanje = _context.IProducentRepository.GetById(id);
            if (producentEditovanje == null)
            {
                return View("NotFound");
            }
            return View(producentEditovanje);
        }
        [HttpPost]
        public IActionResult Edit(Producent producent)
        {
        //    if (!ModelState.IsValid) {

        //        return View(producent);
        //    }

            _context.IProducentRepository.Update(producent);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var producentDeletovanja = _context.IProducentRepository.GetById(id);
            if (producentDeletovanja == null)
            {
                return View("NotFound");
            }
            return View(producentDeletovanja);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            //if (!ModelState.IsValid) {

            //   return View();
            //}

            _context.IProducentRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
