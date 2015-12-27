using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services.Interface
{
    interface IBookEditonServices
    {
        void Create(BookEditon instance);

        void Update(BookEditon instance);

        void Delete(int bookEditonId);

        BookEditon GetById(int? bookEditonId);

        IEnumerable<BookEditon> GetAll();

        int GetEditionCountByBookId(int? bookId);
    }
}
