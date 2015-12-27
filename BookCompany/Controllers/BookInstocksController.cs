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

namespace BookCompanyManagement.Controllers
{
    public class BookInstocksController : Controller
    {
        private readonly BcContext _db = new BcContext();

        // GET: BookInstocks
        public ActionResult Index()
        {
            var bookInstocks = _db.BookInstocks.Include(b => b.BookEditon).Include(b => b.PrintShop);
            return View(bookInstocks.ToList());
        }

        // GET: BookInstocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInstock bookInstock = _db.BookInstocks.Find(id);
            if (bookInstock == null)
            {
                return HttpNotFound();
            }
            return View(bookInstock);
        }

        // GET: BookInstocks/Create
        public ActionResult Create()
        {
            ViewBag.BookEditonId = new SelectList(_db.BookEditons, "BookEditonId", "BookName");
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName");
            return View();
        }

        // POST: BookInstocks/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookInstockId,BookInstockNname,BookMount,BookEditonId,PrintShopId")] BookInstock bookInstock)
        {
            if (ModelState.IsValid)
            {
                _db.BookInstocks.Add(bookInstock);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookEditonId = new SelectList(_db.BookEditons, "BookEditonId", "BookName", bookInstock.BookEditonId);
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", bookInstock.PrintShopId);
            return View(bookInstock);
        }

        // GET: BookInstocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInstock bookInstock = _db.BookInstocks.Find(id);
            if (bookInstock == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookEditonId = new SelectList(_db.BookEditons, "BookEditonId", "BookName", bookInstock.BookEditonId);
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", bookInstock.PrintShopId);
            return View(bookInstock);
        }

        // POST: BookInstocks/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookInstockId,BookInstockNname,BookMount,BookEditonId,PrintShopId")] BookInstock bookInstock)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(bookInstock).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookEditonId = new SelectList(_db.BookEditons, "BookEditonId", "BookName", bookInstock.BookEditonId);
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", bookInstock.PrintShopId);
            return View(bookInstock);
        }

        // GET: BookInstocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInstock bookInstock = _db.BookInstocks.Find(id);
            if (bookInstock == null)
            {
                return HttpNotFound();
            }
            return View(bookInstock);
        }

        // POST: BookInstocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookInstock bookInstock = _db.BookInstocks.Find(id);
            _db.BookInstocks.Remove(bookInstock);
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

        public PartialViewResult _PartialPageBookInstocks()
        {
            var bookInstocks = _db.BookInstocks.Include(b => b.BookEditon).Include(b => b.PrintShop);
            return PartialView(bookInstocks.ToList());
        }
    }
}
