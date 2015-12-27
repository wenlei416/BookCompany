using System;
using System.Collections.Generic;
using System.Data.Entity;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL
{
    public class PapermillRepository : GenericRepository<PaperMill>,IPapermillRepository
    {

        public PaperMill GetById(int papermillId)
        {
            return Get(b => b.PaperMillId == papermillId);
        }
    }
}