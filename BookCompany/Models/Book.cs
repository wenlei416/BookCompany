using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int BookId { get; set; }

        [Display(Name = "书名")]
        public string BookName { get; set; }

        [Display(Name = "出版社")]
        public string PublishingHouse { get; set; }
        public string ISBN { get; set; }

        /*-----------版次----------*/
        public virtual ICollection<BookEditon> BookEditons { get; set; }

    }
}