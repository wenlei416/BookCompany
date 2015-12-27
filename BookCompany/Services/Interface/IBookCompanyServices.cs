using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services.Interface
{
    public interface IBookCompanyServices
    {
        void Create(BookCompany instance);

        void Update(BookCompany instance);

        void Delete(int bookCompanId);

        bool IsExists(int bookCompanId);

        BookCompany GetById(int? bookCompanId);

        IEnumerable<BookCompany> GetAll();

    }
}
