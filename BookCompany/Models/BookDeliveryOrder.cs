using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    public class BookDeliveryOrder
    {
        [HiddenInput(DisplayValue = false)]
        public int BookDeliveryOrderId { get; set; }

        public string BookDeliveryOrderName { get; set; }

        //订单的提出日期
        [Display(Name = "下单日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTime { get; set; }

        /*-----------承印厂----------*/
        public int PrintShopId { get; set; }
        public virtual PrintShop PrintShop { get; set; }

        /*-----------书对应的版本-----------*/
        public int BookEditonId { get; set; }
        public virtual BookEditon BookEditon { get; set; }
        
        /*-----------送货安排-----------*/
        public virtual ICollection<BookDelivery> BookDeliverys { get; set; }




    }
}