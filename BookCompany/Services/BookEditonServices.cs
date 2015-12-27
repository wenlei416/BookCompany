using System.Collections.Generic;
using System.Linq;
using BookCompanyManagement.DAL;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services.Interface;

namespace BookCompanyManagement.Services
{
    public class BookEditonServices : IBookEditonServices
    {
        private readonly IBookEditonRepository _bookEditonRepository = new BookEditonRepository();
        public void Create(BookEditon instance)
        {
            _bookEditonRepository.Create(instance);
        }

        public void Update(BookEditon instance)
        {
            _bookEditonRepository.Update(instance);
        }

        public void Delete(int bookEditonId)
        {
            var bookEdition = _bookEditonRepository.GetById(bookEditonId);
            _bookEditonRepository.Delete(bookEdition);
        }

        public BookEditon GetById(int? bookEditonId)
        {
            return _bookEditonRepository.GetById(bookEditonId);
        }

        public IEnumerable<BookEditon> GetAll()
        {
            return _bookEditonRepository.GetAll();
        }

        public int GetEditionCountByBookId(int? bookId)
        {
            return GetAll().Count(b => b.BookId == bookId);
        }
    }
}