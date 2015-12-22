using System.Collections.Generic;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL.Abstract
{
    public interface IBookRepository
    {

        void DeleteByPrimaryKey(int bookId);

        void Insert(Book book);

        PaperMakingOrder SelectByPrimaryKey(int bookId);

        void Update(Book book);

        IEnumerable<Book> SelectBooks();

        void Save();
    
    }
}