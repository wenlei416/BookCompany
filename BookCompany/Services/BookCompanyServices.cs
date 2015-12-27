using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services.Interface;

namespace BookCompanyManagement.Services
{
    public class BookCompanyServices : IBookCompanyServices
    {
        private readonly IBookCompanyRepository _bookCompanyRepository = new BookCompanyRepository();

        public void Create(BookCompany instance)
        {
            _bookCompanyRepository.Create(instance);
        }

        public void Update(BookCompany instance)
        {
            _bookCompanyRepository.Update(instance);
        }

        public void Delete(int bookCompanId)
        {
            BookCompany bookCompany = _bookCompanyRepository.GetById(bookCompanId);
            _bookCompanyRepository.Delete(bookCompany);
        }


        public BookCompany GetById(int bookCompanId)
        {
            return _bookCompanyRepository.GetById(bookCompanId); //_db.BookCompany.Find(bookCompanId));
        }

        public IEnumerable<BookCompany> GetAll()
        {
            return _bookCompanyRepository.GetAll();
        }

    }
}