using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BookCompanyManagement.DAL;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services;
using BookCompanyManagement.Services.Interface;

namespace BookCompanyManagement.Controllers
{
    public class BookDeliveriesController : Controller
    {
        private BcContext db = new BcContext();
        private readonly IBookDeliveryServices _bookDeliveryServices=new BookDeliveryServices();

        // GET: BookDeliveries
        public ActionResult Index()
        {
            var bookDeliveries = _bookDeliveryServices.GetAll().AsQueryable().Include(b => b.BookPrintOrder);//db.BookDeliveries.Include(b => b.BookPrintOrder);
            return View(bookDeliveries.ToList());
        }

        // GET: BookDeliveries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDelivery bookDelivery = _bookDeliveryServices.GetById(id);//db.BookDeliveries.Find(id);
            if (bookDelivery == null)
            {
                return HttpNotFound();
            }
            return View(bookDelivery);
        }

        // GET: BookDeliveries/Create
        public ActionResult Create()
        {
            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName");
            return View();
        }

        // POST: BookDeliveries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookDeliveryId,DeliveryType,DeliveryDate,DeliveryQuantily,DeliveryAddress,DeliveryContact,BookPrintOrderId")] BookDelivery bookDelivery)
        {
            if (ModelState.IsValid)
            {
                //db.BookDeliveries.Add(bookDelivery);
                //db.SaveChanges();
                _bookDeliveryServices.Create(bookDelivery);
                return RedirectToAction("Index");
            }

            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName", bookDelivery.BookPrintOrderId);
            return View(bookDelivery);
        }

        // GET: BookDeliveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDelivery bookDelivery = _bookDeliveryServices.GetById(id);//db.BookDeliveries.Find(id);
            if (bookDelivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName", bookDelivery.BookPrintOrderId);
            return View(bookDelivery);
        }

        // POST: BookDeliveries/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookDeliveryId,DeliveryType,DeliveryDate,DeliveryQuantily,DeliveryAddress,DeliveryContact,BookPrintOrderId")] BookDelivery bookDelivery)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(bookDelivery).State = EntityState.Modified;
                //db.SaveChanges();
                _bookDeliveryServices.Update(bookDelivery);
                return RedirectToAction("Index");
            }
            ViewBag.BookPrintOrderId = new SelectList(db.BookPrintOrders, "BookPrintOrderId", "BookPrintOrderName", bookDelivery.BookPrintOrderId);
            return View(bookDelivery);
        }

        // GET: BookDeliveries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDelivery bookDelivery = _bookDeliveryServices.GetById(id);//db.BookDeliveries.Find(id);
            if (bookDelivery == null)
            {
                return HttpNotFound();
            }
            return View(bookDelivery);
        }

        // POST: BookDeliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //BookDelivery bookDelivery = db.BookDeliveries.Find(id);
            //db.BookDeliveries.Remove(bookDelivery);
            //db.SaveChanges();
            _bookDeliveryServices.Delete(id);
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
