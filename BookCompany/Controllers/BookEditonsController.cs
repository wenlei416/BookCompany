using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookCompanyManagement.DAL;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services;
using BookCompanyManagement.Services.Interface;

namespace BookCompanyManagement.Controllers
{
    public class BookEditonsController : Controller
    {
        //private readonly BcContext _db = new BcContext();
        private readonly IBookEditonServices _bookEditonServices=new BookEditonServices();

        // GET: BookEditons/Create/2
        // 这里的id是对应的bookid
        public ActionResult Create(int? id)
        {
            //todo 把id传递给页面，应该有其他更好的方法来传递
            ViewBag.Bookinfo = id;
            var bookEditon = new BookEditon();
            var book = _bookEditonServices.GetById(id);//_db.Books.Find(id);
            //ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName", id);
            if (id != null)
            {
                //todo 存在风险id对应的book不存在
                var editons = _bookEditonServices.GetEditionCountByBookId(id);//_db.BookEditons.Count(b => b.BookId == id);
                bookEditon.Edtion = DateTime.Today.Year + "年" + DateTime.Today.Month + "月" + (editons + 1) + "版";
                bookEditon.BookName = book.BookName;
                bookEditon.ISBN = book.ISBN;
                bookEditon.PublishingHouse = book.PublishingHouse;
                bookEditon.BookId = (int)id;

            }
            return View(bookEditon);
        }

        // POST: BookEditons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookEditonId,BookName,PublishingHouse,ISBN,BookPrice,BookId,Edtion")] BookEditon bookEditon)
        {
            if (ModelState.IsValid)
            {
                _bookEditonServices.Create(bookEditon);
                //_db.BookEditons.Add(bookEditon);
                //_db.SaveChanges();
                return RedirectToAction("Details", "Books", new { id = bookEditon.BookId });
            }

            //ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName", bookEditon.BookId);
            return View(bookEditon);
        }

        // GET: BookEditons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookEditon bookEditon = _bookEditonServices.GetById(id);//_db.BookEditons.Find(id);
            if (bookEditon == null)
            {
                return HttpNotFound();
            }
            //ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName", bookEditon.BookId);
            return View(bookEditon);
        }

        // POST: BookEditons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookEditonId,BookName,PublishingHouse,ISBN,BookPrice,BookId,Edtion")] BookEditon bookEditon)
        {
            if (ModelState.IsValid)
            {
                _bookEditonServices.Update(bookEditon);
                //_db.Entry(bookEditon).State = EntityState.Modified;
                //_db.SaveChanges();
                return RedirectToAction("Details", "Books", new { id = bookEditon.BookId });
            }
            //ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName", bookEditon.BookId);
            return View(bookEditon);
        }

        // GET: BookEditons/5
        //这里的id是bookid
        public ActionResult ListOfBook(int? id)
        {
            var bookEditons = _bookEditonServices.GetAll().AsQueryable().Include(b => b.Book).Where(b => b.BookId == id);
            //var bookEditons = _db.BookEditons.Include(b => b.Book).Where(b => b.BookId == id);
            ViewBag.ThisBookId = id;
            return View(bookEditons.ToList());
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region 暂时用不到的功能
        // GET: BookEditons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookEditon bookEditon = _bookEditonServices.GetById(id);//_db.BookEditons.Find(id);
            if (bookEditon == null)
            {
                return HttpNotFound();
            }
            return View(bookEditon);
        }

        // POST: BookEditons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _bookEditonServices.Delete(id);
            //BookEditon bookEditon = _db.BookEditons.Find(id);
            //_db.BookEditons.Remove(bookEditon);
            //_db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: BookEditons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookEditon bookEditon = _bookEditonServices.GetById(id);//_db.BookEditons.Find(id);
            if (bookEditon == null)
            {
                return HttpNotFound();
            }
            return View(bookEditon);
        }


        // GET: BookEditons
        //public ActionResult Index()
        //{
        //    var bookEditons = _db.BookEditons.Include(b => b.Book);
        //    return View(bookEditons.ToList());
        //}
        #endregion
       
        // POST: BookEditions/GetBookEditionsByBookId/5
        [HttpPost]
        public ActionResult GetBookEditionsByBookId(int id)
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();

            var bookEditions = _bookEditonServices.GetAll().Where(p => p.BookId == id);//_db.BookEditons.Where(p => p.BookId == id);

            if (bookEditions.Any())
            {
                foreach (var b in bookEditions)
                {
                    items.Add(new KeyValuePair<string, string>(b.BookEditonId.ToString(), b.Edtion));
                }
            }
            return Json(items);

        }
    }
}
