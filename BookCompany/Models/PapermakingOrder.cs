using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    public class PaperMakingOrder
    {
        [HiddenInput(DisplayValue = false)]
        public int PaperMakingOrderId { get; set; }

        //订单名称
        [Display(Name = "订单名称")]
        public string PaperMakingOrderName { get; set; }

        //订单的量
        [Display(Name = "订量")]
        public int PaperMount { get; set; }

        //订单的状态：已下单，已确认（确认后的订单，变成Printshop的纸张库存）
        [Display(Name = "订单状态")]
        public PaperOrderStatus OrderStatus { get; set; }

        //订单的提出日期
        [Display(Name = "下单日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTime { get; set; }

        //订单的确认日期
        [Display(Name = "结单日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CopmleteDateTime { get; set; }

        /*-----------图书公司-----------*/
        [Display(Name = "下单图书公司")]
        public int BookCompanyId { get; set; }
        public virtual BookCompany BookCompany { get; set; }

        /*-----------纸张----------*/
        [Display(Name = "用纸")]
        public int PaperId { get; set; }
        public virtual Paper Paper { get; set; }

        /*-----------印厂----------*/

        [Display(Name = "送到")]
        public int PrintShopId { get; set; }
        public virtual PrintShop PrintShop { get; set; }

    }
}