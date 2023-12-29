using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Data.Services;
using WebApp.Data.UnitOfWork;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class GlumciController : Controller
    {
        private readonly IUnitOfWork _glumacService;
        public GlumciController(IUnitOfWork glumacService)
        {
            _glumacService = glumacService;
        }
        public IActionResult Index()
        {
            var listaGlumaca = _glumacService.IGlumacRepository.GetAll();
            return View(listaGlumaca);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Glumac glumac)
        {
            //if (!ModelState.IsValid) {

            //    return View(glumac);
            //}

            _glumacService.IGlumacRepository.Add(glumac);
            return RedirectToAction("Index");   
        }
        public IActionResult Details(int id)
        {
            var glumacDetalji = _glumacService.IGlumacRepository.GetById(id);
            if(glumacDetalji == null) {
                return View("NotFound");
            }
            return View(glumacDetalji);
        }
        public IActionResult Edit(int id)
        {
            var glumacEditovanje = _glumacService.IGlumacRepository.GetById(id);
            if (glumacEditovanje == null)
            {
                return View("NotFound");
            }
            return View(glumacEditovanje);
        }
        [HttpPost]
        public IActionResult Edit(Glumac glumac)
        {
            //if (!ModelState.IsValid) {

            //    return View(glumac);
            //}

            _glumacService.IGlumacRepository.Update(glumac);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var glumacDeletovanja = _glumacService.IGlumacRepository.GetById(id);
            if (glumacDeletovanja == null)
            {
                return View("NotFound");
            }
            return View(glumacDeletovanja);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            //if (!ModelState.IsValid) {

            //    return View(glumac);
            //}

            _glumacService.IGlumacRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
