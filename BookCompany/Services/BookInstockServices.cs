using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services.Interface;

namespace BookCompanyManagement.Services
{
    public class BookInstockServices:IBookInstockServices
    {
        readonly IBookInstockRepository _bookInstockRepository=new BookInstockRepository();
        private readonly BcContext _db = new BcContext();

        public void Create(BookInstock instance)
        {
            _bookInstockRepository.Create(instance);
        }

        public void Update(BookInstock instance)
        {
            _bookInstockRepository.Update(instance);
        }

        public void Delete(int bookInstockId)
        {
            var b = _bookInstockRepository.GetById(bookInstockId);
            _bookInstockRepository.Delete(b);
        }

        public BookInstock GetById(int? bookInstockId)
        {
            return _bookInstockRepository.GetById(bookInstockId);
        }

        public IEnumerable<BookInstock> GetAll()
        {
            return _bookInstockRepository.GetAll();
        }

        public void AddBookMount(int bookPrintOrderId)
        {
            //找关键对象：订单，印厂，书（版本）
            BookPrintOrder bookPrintOrder = _db.BookPrintOrders.Find(bookPrintOrderId);
            PrintShop printShop = _db.Printshop.Find(bookPrintOrder.PrintShopId);
            BookEditon bookEditon = _db.BookEditons.Find(bookPrintOrder.BookEditonId);

            //业务逻辑
            //纸厂有书籍库存，且有这张订单中书的库存，就增加这种书的库存
            //否则，就增加一种新书籍库存
            if (printShop.BookInstocks != null && printShop.BookInstocks.Any(b => b.BookEditonId == bookPrintOrder.BookEditonId))
            {
                var bookInstock = printShop.BookInstocks.SingleOrDefault(b => b.BookEditonId == bookPrintOrder.BookEditonId);
                if (bookInstock != null)
                {
                    bookInstock.BookMount =bookInstock.BookMount+ bookPrintOrder.BookPrintMount;
                    _db.Entry(bookInstock).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            else
            {
                var b = new BookInstock()
                {
                    BookMount = bookPrintOrder.BookPrintMount,
                    BookEditonId = bookPrintOrder.BookEditonId,
                    PrintShopId = printShop.PrintShopId
                };
                _db.BookInstocks.Add(b);
                _db.SaveChanges();
            }

        }

        public void RemoveBookMountByPrintOrder(int bookPrintOrderId)
        {
            BookPrintOrder bookPrintOrder = _db.BookPrintOrders.Find(bookPrintOrderId);
            PrintShop printShop = _db.Printshop.Find(bookPrintOrder.PrintShopId);
            BookEditon bookEditon = _db.BookEditons.Find(bookPrintOrder.BookEditonId);
            if (printShop.BookInstocks != null &&
                printShop.BookInstocks.Any(b => b.BookEditonId == bookPrintOrder.BookEditonId))
            {
                //todo:要判断一下书的数量是否足够，不够的处理逻辑是什么，前端先检查一次
                var bookInstock = printShop.BookInstocks.SingleOrDefault(b => b.BookEditonId == bookPrintOrder.BookEditonId);
                if (bookInstock != null)
                {
                    bookInstock.BookMount =bookInstock.BookMount- bookPrintOrder.BookDeliverys.Sum(d=>d.DeliveryQuantily);
                    _db.Entry(bookInstock).State = EntityState.Modified;
                    _db.SaveChanges();
                }

            }
        }

        //这里存在一个问题，印书时直接发货，用上面的方法，如果是单独通过出货单出货的，还需要再处理
        //先不分，回头拆分成两个方法，调用同一个基础方法
        public void RemoveBookMountByDeliveryOrder(int bookDeliveryOrderId)
        {
            throw new NotImplementedException();
        }
    }
}