using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services.Interface
{
    interface IBookServices
    {
         int CreateReturnId(Book book);

         void Create(Book instance);

         void Update(Book instance);

         void Delete(int bookId);

         Book GetById(int? bookId);

         IEnumerable<Book> GetAll();

    }
}
