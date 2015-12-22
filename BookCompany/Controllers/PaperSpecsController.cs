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
    public class PaperSpecsController : Controller
    {
        private readonly BcContext _db = new BcContext();

        // GET: PaperSpecs
        public ActionResult Index()
        {
            return View(_db.Paperspec.ToList());
        }

        // GET: PaperSpecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperSpec paperSpec = _db.Paperspec.Find(id);
            if (paperSpec == null)
            {
                return HttpNotFound();
            }
            return View(paperSpec);
        }

        // GET: PaperSpecs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaperSpecs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperSpecId,PaperSpecName,PaperType,PaperWeight,PaperSize,PaperDescription,IsDeleted")] PaperSpec paperSpec)
        {
            if (ModelState.IsValid)
            {
                //纸品的名称，自动生成，不人工写
                paperSpec.PaperSpecName = paperSpec.PaperType + "，" + paperSpec.PaperWeight + "g，" + paperSpec.PaperSize;
                _db.Paperspec.Add(paperSpec);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paperSpec);
        }

        // GET: PaperSpecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperSpec paperSpec = _db.Paperspec.Find(id);
            if (paperSpec == null)
            {
                return HttpNotFound();
            }
            return View(paperSpec);
        }

        // POST: PaperSpecs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperSpecId,PaperSpecName,PaperType,PaperWeight,PaperSize,PaperDescription,IsDeleted")] PaperSpec paperSpec)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(paperSpec).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paperSpec);
        }

        // GET: PaperSpecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperSpec paperSpec = _db.Paperspec.Find(id);
            if (paperSpec == null)
            {
                return HttpNotFound();
            }
            return View(paperSpec);
        }

        // POST: PaperSpecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaperSpec paperSpec = _db.Paperspec.Find(id);
            _db.Paperspec.Remove(paperSpec);
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
