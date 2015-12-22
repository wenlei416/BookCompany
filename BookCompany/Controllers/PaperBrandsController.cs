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
    public class PaperBrandsController : Controller
    {
        private readonly BcContext _db = new BcContext();

        // GET: PaperBrands
        public ActionResult Index()
        {
            var paperBrands = _db.PaperBrands.Include(p => p.PaperMill);
            return View(paperBrands.ToList());
        }

        // GET: PaperBrands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperBrand paperBrand = _db.PaperBrands.Find(id);
            if (paperBrand == null)
            {
                return HttpNotFound();
            }
            return View(paperBrand);
        }

        // GET: PaperBrands/Create
        public ActionResult Create()
        {
            ViewBag.PaperMillId = new SelectList(_db.Papermills, "PaperMillId", "PaperMillName");
            return View();
        }

        // POST: PaperBrands/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperBrandId,PaperBrandName,PaperMillId")] PaperBrand paperBrand)
        {
            if (ModelState.IsValid)
            {
                _db.PaperBrands.Add(paperBrand);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaperMillId = new SelectList(_db.Papermills, "PaperMillId", "PaperMillName", paperBrand.PaperMillId);
            return View(paperBrand);
        }

        // GET: PaperBrands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperBrand paperBrand = _db.PaperBrands.Find(id);
            if (paperBrand == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaperMillId = new SelectList(_db.Papermills, "PaperMillId", "PaperMillName", paperBrand.PaperMillId);
            return View(paperBrand);
        }

        // POST: PaperBrands/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperBrandId,PaperBrandName,PaperMillId")] PaperBrand paperBrand)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(paperBrand).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaperMillId = new SelectList(_db.Papermills, "PaperMillId", "PaperMillName", paperBrand.PaperMillId);
            return View(paperBrand);
        }

        // GET: PaperBrands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperBrand paperBrand = _db.PaperBrands.Find(id);
            if (paperBrand == null)
            {
                return HttpNotFound();
            }
            return View(paperBrand);
        }

        // POST: PaperBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaperBrand paperBrand = _db.PaperBrands.Find(id);
            _db.PaperBrands.Remove(paperBrand);
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

        public PartialViewResult _PartialPageBrandofMill(int id)
        {
            var paperBrands = _db.PaperBrands.Include(p => p.PaperMill).Where(p => p.PaperMillId == id);

            return PartialView(paperBrands);
        }


        // POST: PaperBrands/GetPaperBrandsByMillId
        [HttpPost]
        public JsonResult GetPaperBrandsByMillId(int id)
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();

            var paperBrands = _db.PaperBrands.Where(p => p.PaperMillId == id);

            if (paperBrands.Any())
            {
                foreach (var b in paperBrands)
                {
                    items.Add(new KeyValuePair<string, string>(b.PaperBrandId.ToString(),b.PaperBrandName));
                }
            }
            return Json(items);
        }

    }
}
