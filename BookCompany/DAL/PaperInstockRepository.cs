using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL
{
    public class PaperInstockRepository : GenericRepository<PaperInstock>, IPaperInstockRepository
    {
        public PaperInstock GetById(int? paperInstockId)
        {
            return this.Get(p => p.PaperInstockId == paperInstockId);
        }
    }
}
