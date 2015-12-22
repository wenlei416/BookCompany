using System;
using System.Linq;
using BookCompanyManagement.DAL;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services
{
    public class BookPrintOrderServices
    {
        private readonly BcContext _db = new BcContext();

        public void CreateBookPrintOrder(BookPrintOrder bookPrintOrder)
        {
            _db.BookPrintOrders.Add(bookPrintOrder);
            _db.SaveChanges();
        }

        private int? GetBookPrintOrderNumByMonthBookcompy(int month, int year)
        {
            return _db.BookPrintOrders.Count(t => t.CreateDateTime.Month == month
                                                  && t.CreateDateTime.Year == year);
        }

        private int? GetBookPrintOrderNumByMonthBookcompy(DateTime date)
        {
            return _db.BookPrintOrders.Count(t => t.CreateDateTime.Month == date.Month
                                                  && t.CreateDateTime.Year == date.Year);
            //return GetBookPrintOrderNumByMonthBookcompy(date.Month, date.Year, bookcompanyid);
        }


        public string GetDefaultBookPrintOrderName()
        {
            return DateTime.Today.ToString("yyMM") + string.Format("{0:00}", GetBookPrintOrderNumByMonthBookcompy(DateTime.Today) + 1);
        }

    }
}