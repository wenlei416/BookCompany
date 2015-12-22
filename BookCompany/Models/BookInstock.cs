using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    public class BookInstock
    {
        [HiddenInput(DisplayValue = false)]
        public int BookInstockId { get; set; }
        public string BookInstockNname { get; set; }
        public int BookMount { get; set; }
        /*-----------书对应的版本-----------*/
        public int BookEditonId { get; set; }
        public virtual BookEditon BookEditon { get; set; }
        /*-----------印刷厂-----------*/
        public int PrintShopId { get; set; }
        public virtual PrintShop PrintShop { get; set; }
    }
}