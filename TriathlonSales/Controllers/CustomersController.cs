using Microsoft.AspNetCore.Mvc;
using TriathlonSales.Data;
using TriathlonSales.Models;

namespace TriathlonSales.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Customers> customers = _db.Customers.ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            ViewBag.Countries = _db.Countries.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customers customer)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                TempData["success"] = "Customer created successully";
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Countries = _db.Countries.ToList();

            if(id==null || id==0)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            var customerFromDb = _db.Customers.Find(id);

            if(customerFromDb==null)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            return View(customerFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customers customer)
        {
            if(ModelState.IsValid)
            {
                _db.Customers.Update(customer);
                _db.SaveChanges();
                TempData["success"] = "Customer edited successfully";

                return RedirectToAction("Index");
            }

            return View(customer);
        }


        public IActionResult Delete(int id)
        {
            ViewBag.Countries = _db.Countries.ToList();

            if (id == null || id == 0)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            var customerFromDb = _db.Customers.Find(id);

            if (customerFromDb == null)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            return View(customerFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var customer = _db.Customers.Find(id);

            if(customer==null)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            _db.Customers.Remove(customer);
            _db.SaveChanges();
            TempData["success"] = "Customer deleted successfully";

            return RedirectToAction("Index");
        }

    }
}
