using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL.Abstract
{
    interface IPapermakingOrderRepository
    {
        void DeleteByPrimaryKey(int papermakingOrderId);

        void Insert(PaperMakingOrder papermakingOrder);

        PaperMakingOrder SelectByPrimaryKey(int papermakingOrderId);

        void Update(PaperMakingOrder papermakingOrder);

        IEnumerable<PaperMakingOrder> SelectPapermakingOrder();

        void Save();
    }
}
