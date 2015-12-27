using System.Collections.Generic;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services.Interface
{
    public interface IBookCompanyServices
    {
        void Create(BookCompany instance);

        void Update(BookCompany instance);

        void Delete(int bookCompanyId);

        BookCompany GetById(int? bookCompanyId);

        IEnumerable<BookCompany> GetAll();

    }
}
