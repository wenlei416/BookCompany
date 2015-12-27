using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL.Abstract
{
    interface IBookEditonRepository : IRepository<BookEditon>
    {
        BookEditon GetById(int? bookEditonId);

    }
}
