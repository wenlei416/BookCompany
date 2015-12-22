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
    public class PaperInstocksController : Controller
    {
        private readonly BcContext _db = new BcContext();

        // GET: PaperInstocks
        public ActionResult Index()
        {
            var paperInstcok = _db.PaperInstcok.Include(p => p.Paper).Include(p => p.PrintShop);
            return View(paperInstcok.ToList());
        }

        // GET: PaperInstocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperInstock paperInstock = _db.PaperInstcok.Find(id);
            if (paperInstock == null)
            {
                return HttpNotFound();
            }
            return View(paperInstock);
        }

        // GET: PaperInstocks/Create
        public ActionResult Create()
        {
            ViewBag.PaperId = new SelectList(_db.Papers, "PaperId", "PaperName");
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName");
            return View();
        }

        // POST: PaperInstocks/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperInstockId,PaperInstockNname,PaperMount,PaperId,PrintShopId")] PaperInstock paperInstock)
        {
            if (ModelState.IsValid)
            {
                _db.PaperInstcok.Add(paperInstock);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaperId = new SelectList(_db.Papers, "PaperId", "PaperName", paperInstock.PaperId);
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", paperInstock.PrintShopId);
            return View(paperInstock);
        }

        // GET: PaperInstocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperInstock paperInstock = _db.PaperInstcok.Find(id);
            if (paperInstock == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaperId = new SelectList(_db.Papers, "PaperId", "PaperName", paperInstock.PaperId);
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", paperInstock.PrintShopId);
            return View(paperInstock);
        }

        // POST: PaperInstocks/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperInstockId,PaperInstockNname,PaperMount,PaperId,PrintShopId")] PaperInstock paperInstock)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(paperInstock).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaperId = new SelectList(_db.Papers, "PaperId", "PaperName", paperInstock.PaperId);
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", paperInstock.PrintShopId);
            return View(paperInstock);
        }

        // GET: PaperInstocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperInstock paperInstock = _db.PaperInstcok.Find(id);
            if (paperInstock == null)
            {
                return HttpNotFound();
            }
            return View(paperInstock);
        }

        // POST: PaperInstocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaperInstock paperInstock = _db.PaperInstcok.Find(id);
            _db.PaperInstcok.Remove(paperInstock);
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


        // POST: PrintShops/GetPapersByPrintShopId/5
        [HttpPost]
        public ActionResult GetPapersByPrintShopId(int id)
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();

            var paperInstcok = _db.PaperInstcok.Include(p=>p.Paper).Where(p => p.PrintShopId == id);


            if (paperInstcok.Any())
            {
                foreach (var b in paperInstcok)
                {
                    items.Add(new KeyValuePair<string, string>(b.PaperId.ToString(), b.Paper.PaperName));
                }
            }
            return Json(items);
        }

        public PartialViewResult _PartialPagePaperInStock()
        {
            var paperInstcok = _db.PaperInstcok.Include(p => p.Paper).Include(p => p.PrintShop).OrderBy(p=>p.PrintShopId).ThenBy(p=>p.Paper.PaperBrand.PaperMillId);
            return PartialView(paperInstcok.ToList());
        }

    }
}
