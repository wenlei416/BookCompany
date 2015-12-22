using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    public class Paper
    {
        [HiddenInput(DisplayValue = false)]
        public int PaperId { get; set; }

        [Display(Name = "纸张名称")]
        public string PaperName { get; set; }
        public bool IsDeleted { get; set; }

        /*-------------品牌-------------*/
        [Display(Name = @"品牌")]
        public int PaperBrandId { get; set; }
        public virtual PaperBrand PaperBrand { get; set; }

        /*-------------纸品-------------*/
        public int PaperSpecId { get; set; }
        [Display(Name = @"纸品")]
        public virtual PaperSpec PaperSpec { get; set; }
    }
}