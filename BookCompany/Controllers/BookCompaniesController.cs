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
    public class BookCompaniesController : Controller
    {
        private readonly BcContext _db = new BcContext();

        // GET: BookCompanies
        public ActionResult Index()
        {
            return View(_db.BookCompany.ToList());
        }

        // GET: BookCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCompany bookCompany = _db.BookCompany.Find(id);
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
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookCompanyId,BookCompanyName,BookCompanyDescription,IsDeleted")] BookCompany bookCompany)
        {
            if (ModelState.IsValid)
            {
                _db.BookCompany.Add(bookCompany);
                _db.SaveChanges();
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
            BookCompany bookCompany = _db.BookCompany.Find(id);
            if (bookCompany == null)
            {
                return HttpNotFound();
            }
            return View(bookCompany);
        }

        // POST: BookCompanies/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookCompanyId,BookCompanyName,BookCompanyDescription,IsDeleted")] BookCompany bookCompany)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(bookCompany).State = EntityState.Modified;
                _db.SaveChanges();
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
            BookCompany bookCompany = _db.BookCompany.Find(id);
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
            BookCompany bookCompany = _db.BookCompany.Find(id);
            _db.BookCompany.Remove(bookCompany);
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

        // GET: BookCompanies/stocks
        public ActionResult Stocks()
        {
            return View();
        }

    }
}
