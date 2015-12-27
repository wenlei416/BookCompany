using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL
{
    public class BookCompanyRepository:GenericRepository<BookCompany>,IBookCompanyRepository
    {
        public BookCompany GetById(int bookCompanyId)
        {
            return this.Get(b => b.BookCompanyId == bookCompanyId);
        }
    }
}