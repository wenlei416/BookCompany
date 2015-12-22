using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    /// <summary>
    /// 图书公司实体
    /// </summary>
    public class BookCompany
    {
        [HiddenInput(DisplayValue = false)]
        public int BookCompanyId { get; set; }

        [Display(Name = "图书公司名称")]
        public string BookCompanyName { get; set; }

        [Display(Name = "图书公司信息")]
        public string BookCompanyDescription { get; set; }
        public bool IsDeleted { get; set; }

        /*-----------买纸的订单-----------*/
        public virtual ICollection<PaperMakingOrder> PaperMakingOrders { get; set; }
        /*-----------印书的订单-----------*/
        public virtual ICollection<BookPrintOrder> BookPrintOrders { get; set; }

    }
}