using System.Collections.Generic;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL.Abstract
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetById(int? bookId);
    
    }
}