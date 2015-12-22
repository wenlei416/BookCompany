using System;
using System.Collections.Generic;
using System.Data.Entity;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL
{
    public class PapermillRepository : IPapermillRepository, IDisposable
    {
        private readonly BcContext _bcContext;

        private bool _disposed = false;

        public PapermillRepository(BcContext bcContext)
        {
            _bcContext = bcContext;
        }

        public void DeleteByPrimaryKey(int papermillId)
        {
            var papermill=_bcContext.Papermills.Find(papermillId);
            if (papermill != null)
                _bcContext.Papermills.Remove(papermill);
        }

        public void Insert(PaperMill papermill)
        {
            _bcContext.Papermills.Add(papermill);
        }

        public PaperMill SelectByPrimaryKey(int papermillId)
        {
            return _bcContext.Papermills.Find(papermillId);
        }

        public void Update(PaperMill papermill)
        {
            _bcContext.Entry(papermill).State=EntityState.Modified;
        }

        public IEnumerable<PaperMill> SelectPapermill()
        {
            return _bcContext.Papermills;
        }

        public void Save()
        {
            _bcContext.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _bcContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}