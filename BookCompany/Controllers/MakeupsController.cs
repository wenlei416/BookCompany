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
    public class MakeupsController : Controller
    {
        private BcContext db = new BcContext();

        // GET: Makeups
        public ActionResult Index()
        {
            var makeups = db.Makeups.Include(m => m.BookPrintOrder);
            return View(makeups.ToList());
        }

        // GET: Makeups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makeup makeup = db.Makeups.Find(id);
            if (makeup == null)
            {
                return HttpNotFound();
            }
            return View(makeup);
        }

        // GET: Makeups/Create
        public ActionResult Create()
        {
            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName");
            return View();
        }

        // POST: Makeups/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MakeupId,MakeupName,MakeupType,Count,BookPrintOrderId")] Makeup makeup)
        {
            if (ModelState.IsValid)
            {
                db.Makeups.Add(makeup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName", makeup.BookPrintOrderId);
            return View(makeup);
        }

        // GET: Makeups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makeup makeup = db.Makeups.Find(id);
            if (makeup == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName", makeup.BookPrintOrderId);
            return View(makeup);
        }

        // POST: Makeups/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MakeupId,MakeupName,MakeupType,Count,BookPrintOrderId")] Makeup makeup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makeup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName", makeup.BookPrintOrderId);
            return View(makeup);
        }

        // GET: Makeups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makeup makeup = db.Makeups.Find(id);
            if (makeup == null)
            {
                return HttpNotFound();
            }
            return View(makeup);
        }

        // POST: Makeups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Makeup makeup = db.Makeups.Find(id);
            db.Makeups.Remove(makeup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
