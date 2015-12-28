using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services.Interface
{
    interface IBookDeliveryServices
    {
        void Create(BookDelivery instance);

        void Update(BookDelivery instance);

        void Delete(int bookDeliveryId);

        BookDelivery GetById(int? bookDeliveryId);

        IEnumerable<BookDelivery> GetAll();
    }
}
