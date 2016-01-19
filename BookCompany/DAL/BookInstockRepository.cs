using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL
{
    public class BookInstockRepository:GenericRepository<BookInstock>,IBookInstockRepository
    {
        public BookInstock GetById(int? bookInstockId)
        {
            return this.Get(b => b.BookInstockId == bookInstockId);
        }
    }
}