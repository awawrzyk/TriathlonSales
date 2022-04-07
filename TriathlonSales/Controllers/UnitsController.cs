using Microsoft.AspNetCore.Mvc;
using TriathlonSales.Data;
using TriathlonSales.Models;

namespace TriathlonSales.Controllers
{
    public class UnitsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public UnitsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Units> objUnitList = _db.Units.ToList();

            return View(objUnitList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Units unit)
        {
            if(ModelState.IsValid)
            {
                _db.Units.Add(unit);
                _db.SaveChanges();
                TempData["success"] = "Unit created successfully";
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        public IActionResult Edit(int id)
        {
            if(id==null || id==0)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            var unitFromDb = _db.Units.Find(id);

            if(unitFromDb==null)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            return View(unitFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Units unit)
        {
            if(ModelState.IsValid)
            {
                _db.Units.Update(unit);
                _db.SaveChanges();
                TempData["success"] = "Unit edited succesfully";

                return RedirectToAction("Index");
            }

            return View(unit);
        }

        public IActionResult Delete(int id)
        {
            if(id==null || id==0)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            var unitFromDb = _db.Units.Find(id);

            if(unitFromDb==null)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            return View(unitFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var unit = _db.Units.Find(id);

            if(unit==null)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            _db.Units.Remove(unit);
            _db.SaveChanges();
            TempData["success"] = "Unit deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
