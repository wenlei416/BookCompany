using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL
{
    public class BookEditonRepository:GenericRepository<BookEditon>, IBookEditonRepository
    {
        public BookEditon GetById(int? bookEditonId)
        {
            return this.Get(e => e.BookEditonId == bookEditonId);
        }
    }
}