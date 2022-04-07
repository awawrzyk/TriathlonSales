using Microsoft.AspNetCore.Mvc;
using TriathlonSales.Data;
using TriathlonSales.Models;

namespace TriathlonSales.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CountriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Countries> countries = _db.Countries.ToList();

            return View(countries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Countries country)
        {
            if(ModelState.IsValid)
            {
                _db.Countries.Add(country);
                _db.SaveChanges();
                TempData["success"] = "Country created successfully";
                return RedirectToAction("Index");
            }

            return View(country);
        }

        public IActionResult Edit(int id)
        {
            if(id==null || id==0)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            var countryFromDb = _db.Countries.Find(id);

            if(countryFromDb==null)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            return View(countryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Countries country)
        {
            if(ModelState.IsValid)
            {
                _db.Countries.Update(country);
                _db.SaveChanges();
                TempData["success"] = "Country edited successfully";

                return RedirectToAction("Index");
            }

            return View(country);
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            var countryFromDb=_db.Countries.Find(id);

            if( countryFromDb==null)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            return View(countryFromDb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var country = _db.Countries.Find(id);
            if(country==null)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            _db.Countries.Remove(country);
            _db.SaveChanges();
            TempData["sucess"] = "Country deleted successfully";

            return RedirectToAction("Index");

        }
    }
}
