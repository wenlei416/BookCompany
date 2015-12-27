using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services.Interface;

namespace BookCompanyManagement.Services
{
    public class BookCompanyServices:IBookCompanyServices
    {
        private readonly BcContext _db = new BcContext();

        public void Create(BookCompany instance)
        {
            _db.BookCompany.Add(instance);
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Update(BookCompany instance)
        {
            _db.Entry(instance).State = EntityState.Modified;
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Delete(int bookCompanId)
        {
            BookCompany bookCompany = _db.BookCompany.Find(bookCompanId);// _db.BookCompany.Find(id);
            _db.BookCompany.Remove(bookCompany);
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public bool IsExists(int bookCompanId)
        {
            return _db.BookCompany.Any(b => b.BookCompanyId == bookCompanId);
            //throw new NotImplementedException();
        }

        public BookCompany GetById(int? bookCompanId)
        {
            return _db.BookCompany.Find(bookCompanId);
            //throw new NotImplementedException();
        }

        public IEnumerable<BookCompany> GetAll()
        {
            return _db.BookCompany;
        }

    }
}