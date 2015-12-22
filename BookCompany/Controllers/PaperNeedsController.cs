using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BookCompanyManagement.DAL;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Controllers
{
    public class PaperNeedsController : Controller
    {
        private BcContext db = new BcContext();

        // GET: PaperNeeds
        public ActionResult Index()
        {
            var paperNeeds = db.PaperNeeds.Include(p => p.BookPrintOrder).Include(p => p.Paper);
            return View(paperNeeds.ToList());
        }

        // GET: PaperNeeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperNeed paperNeed = db.PaperNeeds.Find(id);
            if (paperNeed == null)
            {
                return HttpNotFound();
            }
            return View(paperNeed);
        }

        // GET: PaperNeeds/Create
        public ActionResult Create()
        {
            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName");
            ViewBag.PaperId = new SelectList(db.Papers, "PaperId", "PaperName");
            return View();
        }

        // POST: PaperNeeds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperNeedId,PaperNeedName,PaperId,PaperNeedMount,PageType,PaperFormat,Need,PaperWastage,PaperCount,Technological,BookPrintOrderId")] PaperNeed paperNeed)
        {
            if (ModelState.IsValid)
            {
                db.PaperNeeds.Add(paperNeed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName", paperNeed.BookPrintOrderId);
            ViewBag.PaperId = new SelectList(db.Papers, "PaperId", "PaperName", paperNeed.PaperId);
            return View(paperNeed);
        }

        // GET: PaperNeeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperNeed paperNeed = db.PaperNeeds.Find(id);
            if (paperNeed == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName", paperNeed.BookPrintOrderId);
            ViewBag.PaperId = new SelectList(db.Papers, "PaperId", "PaperName", paperNeed.PaperId);
            return View(paperNeed);
        }

        // POST: PaperNeeds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperNeedId,PaperNeedName,PaperId,PaperNeedMount,PageType,PaperFormat,Need,PaperWastage,PaperCount,Technological,BookPrintOrderId")] PaperNeed paperNeed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paperNeed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName", paperNeed.BookPrintOrderId);
            ViewBag.PaperId = new SelectList(db.Papers, "PaperId", "PaperName", paperNeed.PaperId);
            return View(paperNeed);
        }

        // GET: PaperNeeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperNeed paperNeed = db.PaperNeeds.Find(id);
            if (paperNeed == null)
            {
                return HttpNotFound();
            }
            return View(paperNeed);
        }

        // POST: PaperNeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaperNeed paperNeed = db.PaperNeeds.Find(id);
            db.PaperNeeds.Remove(paperNeed);
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


        // GET: PaperNeeds/Creates
        public ActionResult Creates()
        {
            ViewBag.BookPrintOrderId_1 = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName");
            ViewBag.PaperId_1 = new SelectList(db.Papers, "PaperId", "PaperName");

            //把enum转成和数据库类似的droplist
            Array values = Enum.GetValues(typeof(PageType));
            List<ListItem> items = new List<ListItem>(values.Length);
            foreach (var i in values)
            {
                items.Add(new ListItem
                {
                    Text = Enum.GetName(typeof(PageType), i),
                    Value = i.ToString()
                });
            }
            ViewBag.PageType_1 = new SelectList(items, "Value", "Text");

            return View();
        }


    }
}
