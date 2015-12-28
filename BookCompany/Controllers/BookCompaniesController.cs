using System.Net;
using System.Web.Mvc;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services;
using BookCompanyManagement.Services.Interface;

namespace BookCompanyManagement.Controllers
{
    public class BookCompaniesController : Controller
    {
        private readonly IBookCompanyServices _bookCompanyServices;

        public BookCompaniesController()
        {
            _bookCompanyServices = new BookCompanyServices();
        }

        // GET: BookCompanies
        public ActionResult Index()
        {
            return View(_bookCompanyServices.GetAll());
            //return View(_db.BookCompany.ToList());
        }

        // GET: BookCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCompany bookCompany = _bookCompanyServices.GetById(id);//_db.BookCompany.Find(id);
            if (bookCompany == null)
            {
                return HttpNotFound();
            }
            return View(bookCompany);
        }

        // GET: BookCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookCompanies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookCompanyId,BookCompanyName,BookCompanyDescription,IsDeleted")] BookCompany bookCompany)
        {
            if (ModelState.IsValid)
            {
                _bookCompanyServices.Create(bookCompany);
                //_db.BookCompany.Add(bookCompany);
                //_db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookCompany);
        }

        // GET: BookCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCompany bookCompany = _bookCompanyServices.GetById(id);//_db.BookCompany.Find(id);
            if (bookCompany == null)
            {
                return HttpNotFound();
            }
            return View(bookCompany);
        }

        // POST: BookCompanies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookCompanyId,BookCompanyName,BookCompanyDescription,IsDeleted")] BookCompany bookCompany)
        {
            if (ModelState.IsValid)
            {
                _bookCompanyServices.Update(bookCompany);
                //_db.Entry(bookCompany).State = EntityState.Modified;
                //_db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookCompany);
        }

        // GET: BookCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCompany bookCompany = _bookCompanyServices.GetById(id);//_db.BookCompany.Find(id);
            if (bookCompany == null)
            {
                return HttpNotFound();
            }
            return View(bookCompany);
        }

        // POST: BookCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _bookCompanyServices.Delete(id);
            //BookCompany bookCompany = _bookCompanyServices.GetById(id);// _db.BookCompany.Find(id);
            //_db.BookCompany.Remove(bookCompany);
            //_db.SaveChanges();
            return RedirectToAction("Index");
        }

  

        // GET: BookCompanies/stocks
        public ActionResult Stocks()
        {
            return View();
        }

    }
}
