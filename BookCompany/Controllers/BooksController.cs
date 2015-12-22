using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BookCompanyManagement.DAL;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services;
using BookCompanyManagement.ViewModels;

namespace BookCompanyManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly BcContext _db = new BcContext();
        readonly BookServices _bookServices=new BookServices();

        // GET: Books
        public ActionResult Index()
        {
            return View(_db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            //创建一本新书，一定是第1版
            var newBookCreateVm = new NewBookCreateVm
            {
                Edtion = DateTime.Today.Year + "年" + DateTime.Today.Month + "月1版"
            };
            return View(newBookCreateVm);
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,BookName,PublishingHouse,ISBN,BookPrice,Edtion")] NewBookCreateVm newBookCreateVm)
        {
            //创建一本新书时，同时增加一个版本
            if (ModelState.IsValid)
            {
                Book book=new Book()
                {
                    BookName = newBookCreateVm.BookName,
                    ISBN = newBookCreateVm.ISBN,
                    PublishingHouse=newBookCreateVm.PublishingHouse
                };
                var bookid=_bookServices.AddNewBook(book);
                BookEditon bookEditon=new BookEditon()
                {
                    BookName = newBookCreateVm.BookName,
                    PublishingHouse=newBookCreateVm.PublishingHouse,
                    ISBN=newBookCreateVm.ISBN,
                    BookPrice=newBookCreateVm.BookPrice,
                    Edtion = newBookCreateVm.Edtion,
                    BookId = bookid
                };
                _db.BookEditons.Add(bookEditon);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newBookCreateVm);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,BookName,PublishingHouse,ISBN")] Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(book).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = _db.Books.Find(id);
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
