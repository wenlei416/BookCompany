using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL.Abstract
{
    internal interface IPapermakingOrderRepository : IRepository<PaperMakingOrder>
    {
        PaperMakingOrder GetById(int? papermakingOrderId);
    }
}
