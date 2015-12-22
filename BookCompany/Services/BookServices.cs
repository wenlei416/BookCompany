using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL;
using BookCompanyManagement.Migrations;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services
{
    public class BookServices
    {
        private readonly BcContext _db = new BcContext();

        public int AddNewBook(Book book)
        {
            var b=_db.Books.Add(book);
            _db.SaveChanges();
            return b.BookId;
        }
    }
}