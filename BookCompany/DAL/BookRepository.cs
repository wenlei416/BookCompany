using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL
{
    public class BookRepository:GenericRepository<Book>,IBookRepository
    {
        public Book GetById(int bookId)
        {
            return this.Get(b => b.BookId == bookId);
        }
    }
}