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
    public class PaperMillsController : Controller
    {
        private readonly BcContext _db = new BcContext();

        // GET: PaperMills
        public ActionResult Index()
        {
            return View(_db.Papermills.ToList());
        }

        // GET: PaperMills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperMill paperMill = _db.Papermills.Find(id);
            if (paperMill == null)
            {
                return HttpNotFound();
            }
            return View(paperMill);
        }

        // GET: PaperMills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaperMills/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperMillId,PaperMillName")] PaperMill paperMill)
        {
            if (ModelState.IsValid)
            {
                _db.Papermills.Add(paperMill);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paperMill);
        }

        // GET: PaperMills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperMill paperMill = _db.Papermills.Find(id);
            if (paperMill == null)
            {
                return HttpNotFound();
            }
            return View(paperMill);
        }

        // POST: PaperMills/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperMillId,PaperMillName")] PaperMill paperMill)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(paperMill).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paperMill);
        }

        // GET: PaperMills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperMill paperMill = _db.Papermills.Find(id);
            if (paperMill == null)
            {
                return HttpNotFound();
            }
            return View(paperMill);
        }

        // POST: PaperMills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaperMill paperMill = _db.Papermills.Find(id);
            _db.Papermills.Remove(paperMill);
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
