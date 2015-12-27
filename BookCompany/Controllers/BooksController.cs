using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BookCompanyManagement.DAL;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services;
using BookCompanyManagement.Services.Interface;
using BookCompanyManagement.ViewModels;

namespace BookCompanyManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookServices _bookServices=new BookServices();
        private readonly IBookEditonServices _bookEditonServices=new BookEditonServices();

        // GET: Books
        public ActionResult Index()
        {
            return View(_bookServices.GetAll());

            //return View(_db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _bookServices.GetById(id);//_db.Books.Find(id);
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
                var bookid=_bookServices.CreateReturnId(book);
                BookEditon bookEditon=new BookEditon()
                {
                    BookName = newBookCreateVm.BookName,
                    PublishingHouse=newBookCreateVm.PublishingHouse,
                    ISBN=newBookCreateVm.ISBN,
                    BookPrice=newBookCreateVm.BookPrice,
                    Edtion = newBookCreateVm.Edtion,
                    BookId = bookid
                };
                _bookEditonServices.Create(bookEditon);
                //_db.BookEditons.Add(bookEditon);
                //_db.SaveChanges();
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
            Book book = _bookServices.GetById(id);//_db.Books.Find(id);
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
                _bookServices.Update(book);
                //_db.Entry(book).State = EntityState.Modified;
                //_db.SaveChanges();
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
            Book book = _bookServices.GetById(id);//_db.Books.Find(id));
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
            _bookServices.Delete(id);
            //Book book = _db.Books.Find(id);
            //_db.Books.Remove(book);
            //_db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
