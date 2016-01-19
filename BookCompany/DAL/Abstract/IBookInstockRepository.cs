using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL.Abstract
{
    interface IBookInstockRepository : IRepository<BookInstock>
    {
        BookInstock GetById(int? bookInstockId);
    }
}
