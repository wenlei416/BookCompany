using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookCompanyManagement.ViewModels
{
    public class NewBookCreateVm
    {
        [Display(Name = "书名")]
        public string BookName { get; set; }
        [Display(Name = "出版社")]
        public string PublishingHouse { get; set; }
        public string ISBN { get; set; }

        [Display(Name = "定价")]
        public decimal BookPrice { get; set; }

        [Display(Name = "版次")]
        public string Edtion { get; set; }


    }
}