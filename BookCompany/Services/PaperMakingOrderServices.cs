using System.Collections.Generic;
using BookCompanyManagement.DAL;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services.Interface;

namespace BookCompanyManagement.Services
{
    public class PaperMakingOrderServices:IPaperMakingOrderServices
    {
        private readonly IPapermakingOrderRepository _papermakingOrderRepository=new PapermakingOrderRepository();
        public void Create(PaperMakingOrder instance)
        {
            _papermakingOrderRepository.Create(instance);
        }

        public void Update(PaperMakingOrder instance)
        {
            _papermakingOrderRepository.Update(instance);
        }

        public void Delete(int paperMakingOrderId)
        {
            var p = _papermakingOrderRepository.GetById(paperMakingOrderId);
            _papermakingOrderRepository.Delete(p);
        }

        public PaperMakingOrder GetById(int? paperMakingOrderId)
        {
            return _papermakingOrderRepository.GetById(paperMakingOrderId);
        }

        public IEnumerable<PaperMakingOrder> GetAll()
        {
            return _papermakingOrderRepository.GetAll();
        }
    }
}