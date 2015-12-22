using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL
{
    public class PapermakingOrderRepository : IPapermakingOrderRepository, IDisposable
    {

        private readonly BcContext _bcContext;

        private bool _disposed = false;

        public PapermakingOrderRepository(BcContext bcContext)
        {
            _bcContext = bcContext;
        }


        public void DeleteByPrimaryKey(int papermakingOrderId)
        {
            var papermakingOrder = _bcContext.PapermakingOrder.Find(papermakingOrderId);
            if (papermakingOrder != null)
                _bcContext.PapermakingOrder.Remove(papermakingOrder);
        }

        public void Insert(PaperMakingOrder papermakingOrder)
        {
            _bcContext.PapermakingOrder.Add(papermakingOrder);
        }

        public PaperMakingOrder SelectByPrimaryKey(int papermakingOrderId)
        {
            return _bcContext.PapermakingOrder.Find(papermakingOrderId);

        }

        public void Update(PaperMakingOrder papermakingOrder)
        {
            _bcContext.Entry(papermakingOrder).State = EntityState.Modified;

        }

        public IEnumerable<PaperMakingOrder> SelectPapermakingOrder()
        {
            return _bcContext.PapermakingOrder;
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