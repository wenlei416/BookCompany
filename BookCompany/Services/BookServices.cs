using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Migrations;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services.Interface;

namespace BookCompanyManagement.Services
{
    public class BookServices:IBookServices
    {
        private readonly IBookRepository _bookRepository=new BookRepository();

        public int AddNewBook(Book book)
        {
            _bookRepository.Create(book);
            return book.BookId;
        }
    }
}