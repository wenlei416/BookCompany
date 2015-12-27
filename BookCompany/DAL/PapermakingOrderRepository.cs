using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL
{
    public class PapermakingOrderRepository : GenericRepository<PaperMakingOrder>,IPapermakingOrderRepository
    {

        public PaperMakingOrder GetById(int? papermakingOrderId)
        {
              return Get(b => b.PaperMakingOrderId == papermakingOrderId);
        }
    }
}