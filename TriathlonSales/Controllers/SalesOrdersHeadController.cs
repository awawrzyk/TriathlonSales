using Microsoft.AspNetCore.Mvc;
using TriathlonSales.Data;
using TriathlonSales.Models;

namespace TriathlonSales.Controllers
{
    public class SalesOrdersHeadController : Controller
    {
        private readonly ApplicationDbContext _db;
        public static int customerId;
        public static string docNo;
        public static string customer;

        public SalesOrdersHeadController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<SalesOrdersHead> salesOrdersHeads = _db.SalesOrdersHead.ToList();
            return View(salesOrdersHeads);
        }


        public IActionResult ChooseCustomer()
        {
            IEnumerable<Customers> customers = _db.Customers.ToList();

            ViewBag.DocNo = docNo;
            /*  var customerId = _db.Customers.Find(id);
              if(id!=0 || id!=null)
              {
                  //customerSelectedId = id;
                  _db.CustomerTemporary.Add(new CustomerTemporary { customerId = id });
                  _db.SaveChanges();
                  return RedirectToAction("Create");
              }*/

            return View(customers);
        }


        
        public IActionResult ChooseCustomerClick(int id)
        {
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

            //customerId = customerFromDb.Id;

            // _db.CustomerTemporary.Add(new CustomerTemporary { customerId=customerFromDb.Id });
           _db.CustomerTemporary.Where(c=>c.docNo==docNo).UpdateFromQuery(c=>new CustomerTemporary { customerId=customerFromDb.Id });

            _db.SaveChanges();
            return RedirectToAction("Create");
        }


        public IActionResult Create()
        {
            ViewBag.Customers = _db.Customers.ToList();

            

            //Create docNo

            string lastDocNo = _db.SalesOrdersHead.OrderByDescending(d => d.docNo).Select(n => n.docNo).First().ToString();
            int docLength = lastDocNo.Length;
            string lastNostr = lastDocNo.Trim('S', 'O', '/');
            int lastNo = int.Parse(lastNostr);
            int nextNo = lastNo + 1;
            docNo = "SO/" + nextNo;

            bool existDocNo = _db.CustomerTemporary.Where(c => c.docNo.Equals(docNo)).Count() > 0;

            if (existDocNo == false)
            {
                _db.CustomerTemporary.Add(new CustomerTemporary { docNo = docNo });
                _db.SaveChanges();
            }


            customerId = _db.CustomerTemporary.Where(c => c.docNo == docNo).Select(c => c.customerId).FirstOrDefault();
            if (customerId == 0 || customerId == null)
            {
                customer = "null";
            }
            else
            {
                customer = _db.Customers.Where(c => c.Id == customerId).Select(c => c.Name).ToString();
            }
            ViewBag.CustomerName = customer;

            ViewBag.NextDocNo = docNo;


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SalesOrdersHead salesOrdersHead)
        {
            if(ModelState.IsValid)
            {
                _db.SalesOrdersHead.Add(salesOrdersHead);
                _db.SaveChanges();
                TempData["success"] = "Sales order created successfully";
                return RedirectToAction("Index");
            }

            return View(salesOrdersHead);
        }
    }
}
