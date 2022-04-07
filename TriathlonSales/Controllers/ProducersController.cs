using Microsoft.AspNetCore.Mvc;
using TriathlonSales.Data;
using TriathlonSales.Models;

namespace TriathlonSales.Controllers
{
    public class ProducersController : Controller
    {
        private readonly ApplicationDbContext _db;


        public ProducersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Producers> producers = _db.Producers.ToList();

            return View(producers);
        }

        public IActionResult Create()
        {
            ViewBag.Countries = _db.Countries.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producers producer)
        {
            if(ModelState.IsValid)
            {
                _db.Producers.Add(producer);
                _db.SaveChanges();
                TempData["success"] = "Producer created successfully";
                return RedirectToAction("Index");
            }

            return View(producer);
        }

        public IActionResult Edit(int id)
        {

            ViewBag.Countries = _db.Countries.ToList();
            if (id==null || id==0)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            var producerFromDb = _db.Producers.Find(id);
            
            if(producerFromDb==null)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            return View(producerFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producers producer)
        {
            if(ModelState.IsValid)
            {
                _db.Producers.Update(producer);
                _db.SaveChanges();
                TempData["success"] = "Producer edited successfully";

                return RedirectToAction("Index");
            }

            return View(producer);
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Countries = _db.Countries.ToList();
            if (id == null || id == 0)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            var producerFromDb = _db.Producers.Find(id);

            if (producerFromDb == null)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            return View(producerFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var producer = _db.Producers.Find(id); 
            if(producer== null)
            {
                TempData["error"] = "Not Found";
                return NotFound();
            }

            _db.Producers.Remove(producer);
            _db.SaveChanges();
            TempData["success"] = "Producer deleted succesfully";

            return RedirectToAction("Index");
        }
    }
}
