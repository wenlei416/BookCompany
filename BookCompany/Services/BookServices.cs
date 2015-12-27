using System.Collections.Generic;
using BookCompanyManagement.DAL;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services.Interface;

namespace BookCompanyManagement.Services
{
    public class BookServices:IBookServices
    {
        private readonly IBookRepository _bookRepository=new BookRepository();

        public int CreateReturnId(Book book)
        {
            _bookRepository.Create(book);
            return book.BookId;
        }

        public void Create(Book instance)
        {
            _bookRepository.Create(instance);
        }

        public void Update(Book instance)
        {
            _bookRepository.Update(instance);
        }

        public void Delete(int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            _bookRepository.Delete(book);
        }

        public Book GetById(int? bookId)
        {
            return _bookRepository.GetById(bookId);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }
    }
}