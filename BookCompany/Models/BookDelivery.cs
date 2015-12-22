using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    public class BookDelivery
    {
        [HiddenInput(DisplayValue = false)]
        public int BookDeliveryId { get; set; }

        [Display(Name = "书")]
        public BookDeliveryType DeliveryType { get; set; }

        [Display(Name = "送货时间")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "数量/本")]
        public int DeliveryQuantily { get; set; }

        [Display(Name = "交货地点")]
        public string DeliveryAddress { get; set; }

        [Display(Name = "联系人")]
        public string DeliveryContact { get; set; }

        public int? BookPrintOrderId { get; set; }
        public virtual BookPrintOrder BookPrintOrder { get; set; }
        public int? BookDeliveryOrderId { get; set; }
        public virtual BookPrintOrder BookDeliveryOrder { get; set; }


    }
}