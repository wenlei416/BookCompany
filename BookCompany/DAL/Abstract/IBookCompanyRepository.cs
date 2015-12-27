using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL.Abstract
{
    interface IBookCompanyRepository : IRepository<BookCompany>
    {
        BookCompany GetById(int bookCompanyId);
    }
}
