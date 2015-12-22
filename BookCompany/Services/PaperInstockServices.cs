using System.Data.Entity;
using System.Linq;
using BookCompanyManagement.DAL;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services
{
    public class PaperInstockServices
    {
        private readonly BcContext _db = new BcContext();
        //todo:把数据操作抽象成服务

        /// <summary>
        /// 增加纸张库存
        /// </summary>
        /// <param name="papermakingOrderId">造纸订单号</param>
        public void AddPaperMount(int? papermakingOrderId)
        {
            //验证id存在
            if (papermakingOrderId == null)
            {
                return;
            }
            //找到3个关键的对象订单，印厂，纸张
            PaperMakingOrder paperMakingOrder = _db.PapermakingOrder.Find(papermakingOrderId);
            PrintShop printShop = _db.Printshop.Find(paperMakingOrder.PrintShopId);
            Paper paper = _db.Papers.Find(paperMakingOrder.PaperId);

            //业务逻辑
            //纸厂有库存，且有这张订单中纸的库存，就增加这种纸张的库存
            //否则，就增加一种新纸张库存
            if (printShop.PaperInstcoks != null && printShop.PaperInstcoks.Any(t => t.PaperId == paperMakingOrder.PaperId))
            {
                var paperInstcok = printShop.PaperInstcoks.SingleOrDefault(t => t.PaperId == paperMakingOrder.PaperId);
                //感觉这次检查是多余的
                if (paperInstcok != null)
                {
                    paperInstcok.PaperMount += paperMakingOrder.PaperMount;
                    _db.Entry(paperInstcok).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            else
            {
                var p = new PaperInstock()
                {
                    PaperInstockNname = paper.PaperName + "-" + paper.PaperBrand.PaperBrandName + "-" + paper.PaperSpec.PaperSpecName,
                    PaperMount = paperMakingOrder.PaperMount,
                    PaperId = paperMakingOrder.PaperId,
                    PrintShopId = printShop.PrintShopId
                };
                _db.PaperInstcok.Add(p);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// 减少纸张库存
        /// </summary>
        /// <param name="bookPrintOrderId">印书的订单</param>
        public void RemovePaperMount(int bookPrintOrderId)
        {
            BookPrintOrder bookPrintOrder = _db.BookPrintOrders.Find(bookPrintOrderId);
            PrintShop printShop = _db.Printshop.Find(bookPrintOrder.PrintShopId);
            var paperNeed = bookPrintOrder.PaperNeeds;
            foreach (var p in paperNeed)
            {
                //todo:要判断一下纸张的数量是否足够，不够的处理逻辑是什么，前端先检查一次
                if (printShop.PaperInstcoks != null &&
                    printShop.PaperInstcoks.Any(t => t.PaperId == p.PaperId))
                {
                    var paperInstcok = printShop.PaperInstcoks.SingleOrDefault(t => t.PaperId == p.PaperId);
                    if (paperInstcok != null)
                    {
                        paperInstcok.PaperMount -= p.PaperNeedMount;
                        _db.Entry(paperInstcok).State = EntityState.Modified;
                        _db.SaveChanges();
                    }
                }
                else
                {
                    //todo：这段逻辑不对，不能直接建立负值的库存，这段逻辑应该永远走不到才对，选的就是有库存的纸张
                    var paperInstock = new PaperInstock()
                    {
                        PaperInstockNname = p.Paper.PaperName + "-" + p.Paper.PaperBrand.PaperBrandName + "-" + p.Paper.PaperSpec.PaperSpecName,
                        PaperMount = -p.PaperNeedMount,
                        PaperId = p.PaperId,
                        PrintShopId = printShop.PrintShopId
                    };
                    _db.PaperInstcok.Add(paperInstock);
                    _db.SaveChanges();
                }
            }
        }
    }
}