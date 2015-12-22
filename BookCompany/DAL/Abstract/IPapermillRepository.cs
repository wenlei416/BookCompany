using System;
using System.Collections.Generic;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL.Abstract
{
    public interface IPapermillRepository:IDisposable
    {
        void DeleteByPrimaryKey(int papermillId);

        void Insert(PaperMill papermill);

        PaperMill SelectByPrimaryKey(int papermillId);

        void Update(PaperMill papermill);

        IEnumerable<PaperMill> SelectPapermill();

        void Save();

    }
}
