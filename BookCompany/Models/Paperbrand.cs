using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookCompanyManagement.Models
{
    /// <summary>
    /// 纸张品牌
    /// </summary>
    public class PaperBrand
    {
        public int PaperBrandId { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [Display(Name = @"纸张品牌")]
        public string PaperBrandName { get; set; }

        /*-------------和造纸厂的关联关系-------------*/
        public int PaperMillId { get; set; }
        [Display(Name = @"纸厂")]
        public virtual PaperMill PaperMill { get; set; }

        /*-----------纸张-----------*/
        public virtual ICollection<Paper> Papers { get; set; }

    }
}