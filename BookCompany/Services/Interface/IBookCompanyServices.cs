using System.Collections.Generic;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services.Interface
{
    public interface IBookCompanyServices
    {
        void Create(BookCompany instance);

        void Update(BookCompany instance);

        void Delete(int bookCompanId);

        BookCompany GetById(int bookCompanId);

        IEnumerable<BookCompany> GetAll();

    }
}
