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
         int AddNewBook(Book book);

    }
}
