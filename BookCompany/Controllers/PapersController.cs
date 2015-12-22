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
    public class PapersController : Controller
    {
        private readonly BcContext _db = new BcContext();

        // GET: Papers
        public ActionResult Index()
        {
            var papers = _db.Papers.Include(p => p.PaperBrand).Include(p => p.PaperSpec);
            return View(papers.ToList());
        }

        // GET: Papers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = _db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // GET: Papers/Create
        public ActionResult Create()
        {
            ViewBag.PaperBrandId = new SelectList(_db.PaperBrands, "PaperBrandId", "PaperBrandName");
            ViewBag.PaperSpecId = new SelectList(_db.Paperspec, "PaperSpecId", "PaperSpecName");
            return View();
        }
        // GET: Papers/CreateforMill/1
        public ActionResult CreateforMill(int id)
        {
            ViewBag.MillId = id;
            ViewBag.PaperBrandId = new SelectList(_db.PaperBrands.Where(p=>p.PaperMillId==id), "PaperBrandId", "PaperBrandName");
            ViewBag.PaperSpecId = new SelectList(_db.Paperspec, "PaperSpecId", "PaperSpecName");
            return View();
        }
        // POST: Papers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperId,PaperName,IsDeleted,PaperBrandId,PaperSpecId")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                var paperBrandName = _db.PaperBrands.Find(paper.PaperBrandId).PaperBrandName;//paper.PaperBrand.PaperBrandName;
                var paperSpecName = _db.Paperspec.Find(paper.PaperSpecId).PaperSpecName;//paper.PaperSpec.PaperSpecName;
                paper.PaperName = paperBrandName + "( " + paperSpecName + " )";
                _db.Papers.Add(paper);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaperBrandId = new SelectList(_db.PaperBrands, "PaperBrandId", "PaperBrandName", paper.PaperBrandId);
            ViewBag.PaperSpecId = new SelectList(_db.Paperspec, "PaperSpecId", "PaperSpecName", paper.PaperSpecId);
            return View(paper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateforMill([Bind(Include = "PaperId,PaperName,IsDeleted,PaperBrandId,PaperSpecId")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                ViewBag.MillId = _db.PaperBrands.Find(paper.PaperBrandId).PaperMillId;
                var paperBrandName = _db.PaperBrands.Find(paper.PaperBrandId).PaperBrandName;//paper.PaperBrand.PaperBrandName;
                var paperSpecName = _db.Paperspec.Find(paper.PaperSpecId).PaperSpecName;//paper.PaperSpec.PaperSpecName;
                paper.PaperName = paperBrandName + "( " + paperSpecName + " )";
                _db.Papers.Add(paper);
                _db.SaveChanges();
                return RedirectToAction("Details", "PaperMills", new { id = ViewBag.MillId });
            }

            ViewBag.PaperBrandId = new SelectList(_db.PaperBrands, "PaperBrandId", "PaperBrandName", paper.PaperBrandId);
            ViewBag.PaperSpecId = new SelectList(_db.Paperspec, "PaperSpecId", "PaperSpecName", paper.PaperSpecId);
            return View(paper);
        }
        // GET: Papers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = _db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaperBrandId = new SelectList(_db.PaperBrands, "PaperBrandId", "PaperBrandName", paper.PaperBrandId);
            ViewBag.PaperSpecId = new SelectList(_db.Paperspec, "PaperSpecId", "PaperSpecName", paper.PaperSpecId);
            return View(paper);
        }

        // POST: Papers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperId,PaperName,IsDeleted,PaperBrandId,PaperSpecId")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                var paperBrandName = _db.PaperBrands.Find(paper.PaperBrandId).PaperBrandName;//paper.PaperBrand.PaperBrandName;
                var paperSpecName = _db.Paperspec.Find(paper.PaperSpecId).PaperSpecName;//paper.PaperSpec.PaperSpecName;
                paper.PaperName = paperBrandName + "( " + paperSpecName + " )";
                _db.Entry(paper).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaperBrandId = new SelectList(_db.PaperBrands, "PaperBrandId", "PaperBrandName", paper.PaperBrandId);
            ViewBag.PaperSpecId = new SelectList(_db.Paperspec, "PaperSpecId", "PaperSpecName", paper.PaperSpecId);
            return View(paper);
        }

        // GET: Papers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = _db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // POST: Papers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paper paper = _db.Papers.Find(id);
            _db.Papers.Remove(paper);
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


        public PartialViewResult _PartialPagePaperofBrand(int id)
        {
            var papers = _db.Papers.Include(p => p.PaperBrand).Include(p => p.PaperSpec).Where(p=>p.PaperBrandId==id);
            return PartialView(papers.ToList());
        }

        // POST: Papers/GetPapersByMillId
        [HttpPost]
        public JsonResult GetPapersByMillId(int id)
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();

            var papers = _db.Papers.Where(p => p.PaperBrandId == id);

            if (papers.Any())
            {
                foreach (var b in papers)
                {
                    items.Add(new KeyValuePair<string, string>(b.PaperId.ToString(), b.PaperName));
                }
            }
            return Json(items);
        }

    }
}
