using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    public class BookEditon
    {
        [HiddenInput(DisplayValue = false)]
        public int BookEditonId { get; set; }
        [Display(Name = "本版书名")]
        public string BookName { get; set; }

        [Display(Name = "出版社")]
        public string PublishingHouse { get; set; }
        public string ISBN { get; set; }
        
        [Display(Name = "价格")]
        public decimal BookPrice { get; set; }
        
        [Display(Name = "版本")]
        public string Edtion { get; set; }

        /*-----------书----------*/
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

    }
}