using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    public class BookPrintOrder
    {
        [HiddenInput(DisplayValue = false)]
        public int BookPrintOrderId { get; set; }

        [Display(Name = "单号")]
        public string BookPrintOrderName { get; set; }
        //订单的量
        [Display(Name = "印数")]
        public int BookPrintMount { get; set; }

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


        /*-----------书----------*/
        public int BookEditonId { get; set; }
        [Display(Name = "书名")]
        public virtual BookEditon BookEditon { get; set; }
        /*-----------图书公司-----------*/
        public int BookCompanyId { get; set; }
        public virtual BookCompany BookCompany { get; set; }
        /*-----------承印厂----------*/
        public int PrintShopId { get; set; }
        public virtual PrintShop PrintShop { get; set; }

        /*-----------用纸情况-----------*/
        public virtual ICollection<PaperNeed> PaperNeeds { get; set; }

        /*-----------拼版情况-----------*/
        public virtual ICollection<Makeup> Makeups { get; set; }

        /*-----------送货情况-----------*/
        public virtual ICollection<BookDelivery> BookDeliverys { get; set; }


        //印次（版本+印刷次数）
        [Display(Name = "印次")]
        public string PrintNo { get; set; }

        [Display(Name = "开本")]
        public int PageFormat { get; set; }

        [Display(Name = "尺寸")]
        public string PageSize { get; set; }

        [Display(Name = "印张")]
        public float Printsheet { get; set; }

        [Display(Name = "装订")]
        public string Bookbinding { get; set; }

        [Display(Name = "塑封")]
        public string Plasticpackage { get; set; }

        //打包
        [Display(Name = "每标准/自然包")]
        public int Normalpackage { get; set; }

        [Display(Name = "每铁路件")]
        public int Railpackage { get; set; }
    }
}