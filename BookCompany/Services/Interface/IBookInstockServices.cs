using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services.Interface
{
    interface IBookInstockServices
    {
        void Create(BookInstock instance);

        void Update(BookInstock instance);

        void Delete(int bookInstockId);

        BookInstock GetById(int? bookInstockId);

        IEnumerable<BookInstock> GetAll();

        void AddBookMount(int bookPrintOrderId);
        void RemoveBookMountByPrintOrder(int bookPrintOrderId);
        void RemoveBookMountByDeliveryOrder(int bookDeliveryOrderId);
    }
}
