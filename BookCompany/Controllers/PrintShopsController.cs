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
    public class PrintShopsController : Controller
    {
        private readonly BcContext _db = new BcContext();

        // GET: PrintShops
        public ActionResult Index()
        {
            return View(_db.Printshop.ToList());
        }

        // GET: PrintShops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrintShop printShop = _db.Printshop.Find(id);
            if (printShop == null)
            {
                return HttpNotFound();
            }
            return View(printShop);
        }

        // GET: PrintShops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrintShops/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrintShopId,PrintShopName,PrintShopDescription,IsDeleted")] PrintShop printShop)
        {
            if (ModelState.IsValid)
            {
                _db.Printshop.Add(printShop);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(printShop);
        }

        // GET: PrintShops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrintShop printShop = _db.Printshop.Find(id);
            if (printShop == null)
            {
                return HttpNotFound();
            }
            return View(printShop);
        }

        // POST: PrintShops/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrintShopId,PrintShopName,PrintShopDescription,IsDeleted")] PrintShop printShop)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(printShop).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(printShop);
        }

        // GET: PrintShops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrintShop printShop = _db.Printshop.Find(id);
            if (printShop == null)
            {
                return HttpNotFound();
            }
            return View(printShop);
        }

        // POST: PrintShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrintShop printShop = _db.Printshop.Find(id);
            _db.Printshop.Remove(printShop);
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
