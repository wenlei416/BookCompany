using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    public class PaperInstock
    {
        [HiddenInput(DisplayValue = false)]
        public int PaperInstockId { get; set; }
        public string PaperInstockNname { get; set; }
        public float PaperMount { get; set; }
        /*-----------纸张-----------*/
        public int PaperId { get; set; }
        public virtual Paper Paper { get; set; }
        /*-----------印刷厂-----------*/
        public int PrintShopId { get; set; }
        public virtual PrintShop PrintShop { get; set; }

    }
}