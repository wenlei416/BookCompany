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
using BookCompanyManagement.Services;
using BookCompanyManagement.Services.Interface;
using Ninject.Infrastructure.Language;

namespace BookCompanyManagement.Controllers
{
    public class PaperMakingOrdersController : Controller
    {
        private readonly BcContext _db = new BcContext();
        private readonly PaperInstockServices _paperInstcokServices = new PaperInstockServices();
        private readonly IPaperMakingOrderServices _paperMakingOrderServices=new PaperMakingOrderServices();

        // GET: PaperMakingOrders
        public ActionResult Index()
        {
            //var papermakingOrder = _db.PapermakingOrder.Include(p => p.BookCompany).Include(p => p.Paper).Include(p => p.PrintShop);
            var papermakingOrder = _paperMakingOrderServices.GetAll().AsQueryable().Include(p => p.BookCompany).Include(p => p.Paper).Include(p => p.PrintShop);
            return View(papermakingOrder.ToList());
        }

        // GET: PaperMakingOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperMakingOrder paperMakingOrder = _paperMakingOrderServices.GetById(id); //_db.PapermakingOrder.Find(id);
            if (paperMakingOrder == null)
            {
                return HttpNotFound();
            }
            return View(paperMakingOrder);
        }

        // GET: PaperMakingOrders/Create
        public ActionResult Create(int? papermillid, int? paperbrandid)
        {
            ViewBag.BookCompanyId = new SelectList(_db.BookCompany, "BookCompanyId", "BookCompanyName");
            //判断paperbrandid和papermillid对应的对象是否存在,隶属关系是否正确
            var relation = _db.PaperBrands.Any(p => p.PaperBrandId == paperbrandid && p.PaperMillId == papermillid);
            
            
            //无需判断papermillid对应的对象是否存在，不存在会自动选择默认值
            ViewBag.PaperMillId = new SelectList(_db.Papermills, "PaperMillId", "PaperMillName", papermillid);
            //如果papermillid为空，那么另外两个list都设为空，同时不设置默认值
            if (papermillid == null)
            {
                ViewBag.PaperBrandId = new SelectList(Enumerable.Empty<SelectListItem>(), "PaperBrandId", "PaperBrandName") ;
                ViewBag.PaperId = new SelectList(Enumerable.Empty<SelectListItem>(), "PaperId", "PaperName");
            }
            else
            {
                //如果papermillid不为空，PaperBrandslist 有值，且设置默认值。如果paperbrand的id值不对，会自动不设置默认值
                ViewBag.PaperBrandId = new SelectList(_db.PaperBrands.Where(p => p.PaperMillId == papermillid), "PaperBrandId", "PaperBrandName", paperbrandid);

                //如果paperbrandid不为空，且papermill拥有paperbrand（releation所体现），Paperlist 有值，没有默认值。
                //否则paperlist为空
                if (paperbrandid != null && relation)
                {
                    ViewBag.PaperId = new SelectList(_db.Papers.Where(p => p.PaperBrandId == paperbrandid), "PaperId", "PaperName");
                }
                else
                {
                    ViewBag.PaperId = new SelectList(Enumerable.Empty<SelectListItem>(), "PaperId", "PaperName");
                }

            }

            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName");
            return View();
        }

        // POST: PaperMakingOrders/Create
        /// <summary>
        /// 保存买纸订单的action
        /// </summary>
        /// <param name="paperMakingOrder">需要保存进入数据库的对象</param>
        /// <param name="papermillid">用来指定选择的dropdownlist的选项，在提交失败的时候，返回view时能保存住</param>
        /// <param name="paperbrandid">用来指定选择的dropdownlist的选项，在提交失败的时候，返回view时能保存住</param>
        /// <returns></returns>
        //TODO：把初始化dropdownlist的方法抽象出来成为一个方法（放在这里，还是放在service中？）
        //Todo:把逻辑拆分到service中
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperMakingOrderId,PaperMakingOrderName,PaperMount,OrderStatus,CreateDateTime,CopmleteDateTime,BookCompanyId,PaperId,PrintShopId")] PaperMakingOrder paperMakingOrder, int? papermillid, int? paperbrandid)
        {
            if (ModelState.IsValid)
            {
                _db.PapermakingOrder.Add(paperMakingOrder);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookCompanyId = new SelectList(_db.BookCompany, "BookCompanyId", "BookCompanyName", paperMakingOrder.BookCompanyId);

            //判断paperbrandid和papermillid对应的对象是否存在,隶属关系是否正确
            var relation = _db.PaperBrands.Any(p => p.PaperBrandId == paperbrandid && p.PaperMillId == papermillid);


            //无需判断papermillid对应的对象是否存在，不存在会自动选择默认值
            ViewBag.PaperMillId = new SelectList(_db.Papermills, "PaperMillId", "PaperMillName", papermillid);
            //如果papermillid为空，那么另外两个list都设为空，同时不设置默认值
            if (papermillid == null)
            {
                ViewBag.PaperBrandId = new SelectList(Enumerable.Empty<SelectListItem>(), "PaperBrandId", "PaperBrandName");
                ViewBag.PaperId = new SelectList(Enumerable.Empty<SelectListItem>(), "PaperId", "PaperName");
            }
            else
            {
                //如果papermillid不为空，PaperBrandslist 有值，且设置默认值。如果paperbrand的id值不对，会自动不设置默认值
                ViewBag.PaperBrandId = new SelectList(_db.PaperBrands.Where(p => p.PaperMillId == papermillid), "PaperBrandId", "PaperBrandName", paperbrandid);

                //如果paperbrandid不为空，且papermill拥有paperbrand（releation所体现），Paperlist 有值，没有默认值。
                //否则paperlist为空
                if (paperbrandid != null && relation)
                {
                    ViewBag.PaperId = new SelectList(_db.Papers.Where(p => p.PaperBrandId == paperbrandid), "PaperId", "PaperName");
                }
                else
                {
                    ViewBag.PaperId = new SelectList(Enumerable.Empty<SelectListItem>(), "PaperId", "PaperName");
                }

            }

            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", paperMakingOrder.PrintShopId);
            return View(paperMakingOrder);
        }

        // GET: PaperMakingOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperMakingOrder paperMakingOrder = _db.PapermakingOrder.Find(id);
            if (paperMakingOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookCompanyId = new SelectList(_db.BookCompany, "BookCompanyId", "BookCompanyName", paperMakingOrder.BookCompanyId);
            ViewBag.PaperId = new SelectList(_db.Papers, "PaperId", "PaperName", paperMakingOrder.PaperId);
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", paperMakingOrder.PrintShopId);
            return View(paperMakingOrder);
        }

        // POST: PaperMakingOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperMakingOrderId,PaperMakingOrderName,PaperMount,OrderStatus,CreateDateTime,CopmleteDateTime,BookCompanyId,PaperId,PrintShopId")] PaperMakingOrder paperMakingOrder)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(paperMakingOrder).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookCompanyId = new SelectList(_db.BookCompany, "BookCompanyId", "BookCompanyName", paperMakingOrder.BookCompanyId);
            ViewBag.PaperId = new SelectList(_db.Papers, "PaperId", "PaperName", paperMakingOrder.PaperId);
            ViewBag.PrintShopId = new SelectList(_db.Printshop, "PrintShopId", "PrintShopName", paperMakingOrder.PrintShopId);
            return View(paperMakingOrder);
        }

        // GET: PaperMakingOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperMakingOrder paperMakingOrder = _db.PapermakingOrder.Find(id);
            if (paperMakingOrder == null)
            {
                return HttpNotFound();
            }
            return View(paperMakingOrder);
        }

        // POST: PaperMakingOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaperMakingOrder paperMakingOrder = _db.PapermakingOrder.Find(id);
            _db.PapermakingOrder.Remove(paperMakingOrder);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: PaperMakingOrders/Complete/5
        /// <summary>
        /// 确认买纸订单已经完成，并送到印厂，增加印厂纸张的库存
        /// </summary>
        /// <param name="id">买纸订单编号</param>
        /// <returns></returns>
        public ActionResult Complete(int? id)
        {
            //验证id和id所代表的买纸订单存在
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperMakingOrder paperMakingOrder = _db.PapermakingOrder.Find(id);
            if (paperMakingOrder == null)
            {
                return HttpNotFound();
            }

            //设置买纸订单的状态和完成日期
            paperMakingOrder.OrderStatus = PaperOrderStatus.已确认;
            paperMakingOrder.CopmleteDateTime = DateTime.Now;
            //调用纸张库存方法，增加印厂库存
            _paperInstcokServices.AddPaperMount(id);
            //保存买纸订单
            _db.Entry(paperMakingOrder).State = EntityState.Modified;
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

        public PartialViewResult _PartialPagePaperInOrder()
        {
            var paperMarkingOrding = _db.PapermakingOrder.Where(o => o.OrderStatus == PaperOrderStatus.已下单);
            return PartialView(paperMarkingOrding);
        }
    }
}
