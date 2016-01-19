using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services.Interface
{
    interface IPaperInstockServices
    {

        void Create(PaperInstock instance);

        void Update(PaperInstock instance);

        void Delete(int paperInstockId);

        PaperInstock GetById(int? paperInstockId);

        IEnumerable<PaperInstock> GetAll();

    }
}
