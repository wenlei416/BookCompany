using System.Collections.Generic;
using BookCompanyManagement.DAL;
using BookCompanyManagement.DAL.Abstract;
using BookCompanyManagement.Models;
using BookCompanyManagement.Services.Interface;

namespace BookCompanyManagement.Services
{
    public class BookDeliveryServices:IBookDeliveryServices
    {
        private readonly IBookDeliveryRepository _bookDeliveryRepository=new BookDeliveryRepository();
        public void Create(BookDelivery instance)
        {
            _bookDeliveryRepository.Create(instance);
        }

        public void Update(BookDelivery instance)
        {
            _bookDeliveryRepository.Update(instance);
        }

        public void Delete(int bookDeliveryId)
        {
            var bookDelivery = _bookDeliveryRepository.GetById(bookDeliveryId);
            _bookDeliveryRepository.Delete(bookDelivery);
        }

        public BookDelivery GetById(int? bookDeliveryId)
        {
            return _bookDeliveryRepository.GetById(bookDeliveryId);
        }

        public IEnumerable<BookDelivery> GetAll()
        {
            return _bookDeliveryRepository.GetAll();
        }
    }


}