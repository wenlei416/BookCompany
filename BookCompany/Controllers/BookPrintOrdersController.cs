using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using BookCompanyManagement.DAL;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services;

namespace BookCompanyManagement.Controllers
{
    public class BookPrintOrdersController : Controller
    {
        private readonly BcContext _db = new BcContext();
        private readonly BookPrintOrderServices _bookPrintOrderServices = new BookPrintOrderServices();
        private readonly PaperInstockServices _paperInstcokServices = new PaperInstockServices();
        private readonly BookInstockServices _bookInstockServices = new BookInstockServices();



        // GET: BookPrintOrders
        public ActionResult Index()
        {
            var bookPrintOrders = _db.BookPrintOrders.Include(b => b.BookCompany).Include(b => b.BookEditon).Include(b => b.PrintShop);
            return View(bookPrintOrders.ToList());
        }

        // GET: BookPrintOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookPrintOrder bookPrintOrder = _db.BookPrintOrders.Find(id);
            if (bookPrintOrder == null)
            {
                return HttpNotFound();
            }
            return View(bookPrintOrder);
        }

        // GET: BookPrintOrders/Create
        public ActionResult Create()
        {
            ViewBag.BookCompanyId = new SelectList(_db.BookCompany, "BookCompanyId", "BookCompanyName");
            ViewBag.BookEditonId = new SelectList(Enumerable.Empty<SelectListItem>(), "BookEditonId", "Edtion");

            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName");
            ViewBag.PaperId = new SelectList(Enumerable.Empty<SelectListItem>(), "PaperId", "PaperName");
            ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName");

            ViewBag.OrderStatus = EnumHelper.GetSelectList(typeof(PaperOrderStatus));
            ViewBag.PageType = EnumHelper.GetSelectList(typeof(PageType));
            return View();



        }

        // POST: BookPrintOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookPrintOrder bookPrintOrder)
        {
            if (ModelState.IsValid)
            {
                //创建印书订单
                _db.BookPrintOrders.Add(bookPrintOrder);
                _db.SaveChanges();
                //调用纸张库存方法，减少印厂纸张库存
                _paperInstcokServices.RemovePaperMount(bookPrintOrder.BookPrintOrderId);
                return RedirectToAction("Index");
            }

            ViewBag.BookCompanyId = new SelectList(_db.BookCompany, "BookCompanyId", "BookCompanyName", bookPrintOrder.BookCompanyId);
            ViewBag.BookEditonId = new SelectList(_db.BookEditons, "BookEditonId", "BookName", bookPrintOrder.BookEditonId);
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", bookPrintOrder.PrintShopId);
            ViewBag.PaperId = new SelectList(_db.Papers, "PaperId", "PaperName");

            ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName");

            ViewBag.OrderStatus = EnumHelper.GetSelectList(typeof(PaperOrderStatus));
            ViewBag.PageType = EnumHelper.GetSelectList(typeof(PageType));


            return View(bookPrintOrder);
        }

        // GET: BookPrintOrders/Edit/5
        //todo 增加减少各个子对象，同时可以保存
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookPrintOrder bookPrintOrder = _db.BookPrintOrders.Find(id);
            if (bookPrintOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookCompanyId = new SelectList(_db.BookCompany, "BookCompanyId", "BookCompanyName", bookPrintOrder.BookCompanyId);
            ViewBag.BookEditonId = new SelectList(_db.BookEditons, "BookEditonId", "BookName", bookPrintOrder.BookEditonId);
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", bookPrintOrder.PrintShopId);

            ViewBag.PaperList = from p in _db.PaperInstcok
                                where (p.PrintShopId == bookPrintOrder.PrintShopId)
                                select new { PaperId = p.PaperId, PaperName = p.Paper.PaperName };
            return View(bookPrintOrder);
        }

        // POST: BookPrintOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookPrintOrder bookPrintOrder)
        {
            if (ModelState.IsValid)
            {
                foreach (var p in bookPrintOrder.PaperNeeds)
                {
                    _db.Entry(p).State = EntityState.Modified;
                }
                foreach (var m in bookPrintOrder.Makeups)
                {
                    _db.Entry(m).State = EntityState.Modified;
                }
                foreach (var d in bookPrintOrder.BookDeliverys)
                {
                    _db.Entry(d).State = EntityState.Modified;
                }

                _db.Entry(bookPrintOrder).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookCompanyId = new SelectList(_db.BookCompany, "BookCompanyId", "BookCompanyName", bookPrintOrder.BookCompanyId);
            ViewBag.BookEditonId = new SelectList(_db.BookEditons, "BookEditonId", "BookName", bookPrintOrder.BookEditonId);
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", bookPrintOrder.PrintShopId);

            ViewBag.PaperList = from p in _db.PaperInstcok
                                where (p.PrintShopId == bookPrintOrder.PrintShopId)
                                select new { PaperId = p.PaperId, PaperName = p.Paper.PaperName };

            return View(bookPrintOrder);
        }

        // GET: BookPrintOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookPrintOrder bookPrintOrder = _db.BookPrintOrders.Find(id);
            if (bookPrintOrder == null)
            {
                return HttpNotFound();
            }
            return View(bookPrintOrder);
        }

        // POST: BookPrintOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookPrintOrder bookPrintOrder = _db.BookPrintOrders.Find(id);
            _db.BookPrintOrders.Remove(bookPrintOrder);
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

        public string OnPrintNameChanged()
        {
            var bookPrintOrder = _bookPrintOrderServices.GetDefaultBookPrintOrderName();
            return bookPrintOrder;
            //_bookPrintOrderServices.GetDefaultBookPrintOrderName(
        }


        public string GetPrintNoByBookEditionId(int id)
        {
            var printTimes = _db.BookPrintOrders.Count(b => b.BookEditonId == id) + 1;
            var editionName = _db.BookEditons.Find(id).Edtion;
            return editionName + printTimes + "次";
        }

        public ActionResult Complete(int id)
        {
            BookPrintOrder bookPrintOrder = _db.BookPrintOrders.Find(id);
            if (bookPrintOrder == null)
            {
                return HttpNotFound();
            }
            //设置印书订单的状态
            bookPrintOrder.CopmleteDateTime = DateTime.Now;
            bookPrintOrder.OrderStatus = PaperOrderStatus.已确认;

            //调用书籍库存方法，增加印厂图书库存，如果有出库的单子，还需要再出库（纸张库存变化在创建订单的时候就已经完成了）
            _bookInstockServices.AddBookMount(id);
            if (bookPrintOrder.BookDeliverys != null && bookPrintOrder.BookDeliverys.Count > 0)
            {
                _bookInstockServices.RemoveBookMountByPrintOrder(id);
            }

            //保存印书订单
            _db.Entry(bookPrintOrder).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public PartialViewResult _PartialPageBookInOrder()
        {
            var bookPrintOrders = _db.BookPrintOrders.Include(b => b.BookCompany).Include(b => b.BookEditon).Include(b => b.PrintShop);
            return PartialView(bookPrintOrders.ToList());
        }
    }
}
