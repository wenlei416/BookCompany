using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    /// <summary>
    /// 纸张规格
    /// </summary>
    public class PaperSpec
    {
        [HiddenInput(DisplayValue = false)]
        public int PaperSpecId { get; set; }

        [Display(Name = "纸张规格名称")]
        public string PaperSpecName { get; set; }

        [Display(Name = "种类")]
        public string PaperType { get; set; }

        [Display(Name = "克重")]
        public string PaperWeight { get; set; }

        [Display(Name = "尺寸")]
        public string PaperSize { get; set; }

        [Display(Name = "备注")]
        public string PaperDescription { get; set; }

        public bool IsDeleted { get; set; }

        /*-----------订单-----------*/
        public virtual ICollection<PaperMakingOrder> PaperMakingOrders { get; set; }

        /*-----------库存-----------*/
        public virtual ICollection<PaperInstock> PaperInstocks { get; set; }

        /*-----------纸张-----------*/
        public virtual ICollection<Paper> Papers { get; set; }

    }
}