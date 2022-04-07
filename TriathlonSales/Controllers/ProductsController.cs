using Microsoft.AspNetCore.Mvc;
using TriathlonSales.Data;
using TriathlonSales.Models;

namespace TriathlonSales.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Products> products = _db.Products.ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products product)
        {
            if(ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            if(id==null || id==0)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }

            var productFromDb = _db.Products.Find(id);

            if(productFromDb==null)
            {
                if (id == null || id == 0)
                {
                    TempData["error"] = "Not found";
                    return NotFound();
                }
            }

            return View(productFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products product)
        {
            if(ModelState.IsValid)
            {
                _db.Products.Update(product);
                _db.SaveChanges();
                TempData["success"] = "Product edited successfully";

                return RedirectToAction("Index");
            }

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                TempData["error"] = "Not found";
                return NotFound();
            }


            var productFromDb = _db.Products.Find(id);



            if (productFromDb == null)
            {
                if (id == null || id == 0)
                {
                    TempData["error"] = "Not found";
                    return NotFound();
                }
            }

            return View(productFromDb);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var product = _db.Products.Find(id);
            if(product==null)
            {
                TempData["error"] = "Not Found";
                return NotFound();
            }

            _db.Products.Remove(product);
            _db.SaveChanges();
            TempData["success"] = "Product removed successfully";

            return RedirectToAction("Index");
        }
    }
}
