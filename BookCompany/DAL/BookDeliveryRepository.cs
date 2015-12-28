using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL
{
    public class BookDeliveryRepository : GenericRepository<BookDelivery>, IBookDeliveryRepository
    {
        public BookDelivery GetById(int? bookDeliveryId)
        {
            return this.Get(d => d.BookDeliveryId == bookDeliveryId);
        }
    }
}