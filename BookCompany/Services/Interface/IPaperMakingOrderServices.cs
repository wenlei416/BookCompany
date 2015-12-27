using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Services.Interface
{
    interface IPaperMakingOrderServices
    {
        void Create(PaperMakingOrder instance);

        void Update(PaperMakingOrder instance);

        void Delete(int paperMakingOrderId);

        PaperMakingOrder GetById(int? paperMakingOrderId);

        IEnumerable<PaperMakingOrder> GetAll();
    }
}
