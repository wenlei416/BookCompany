using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL.Abstract
{
    interface IPaperInstockRepository : IRepository<PaperInstock>
    {
        PaperInstock GetById(int? paperInstockId);

    }
}
