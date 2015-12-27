using System;
using System.Collections.Generic;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL.Abstract
{
    public interface IPapermillRepository:IRepository<PaperMill>
    {


        PaperMill GetById(int papermillId);




    }
}
