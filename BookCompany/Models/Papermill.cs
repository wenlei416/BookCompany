using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    /// <summary>
    /// 造纸厂实体
    /// </summary>
    public class PaperMill
    {
        [HiddenInput(DisplayValue = false)]
        public int PaperMillId { get; set; }

        /// <summary>
        /// 造纸厂名称
        /// </summary>
        /// 
        [Display(Name = "造纸厂名称")]
        public string PaperMillName { get; set; }


        /*-------------和纸张品牌的关联关系-------------*/
        /// <summary>
        /// 造纸厂拥有的纸张品牌
        /// </summary>
        public virtual ICollection<PaperBrand> PaperBrands { get; set; }

    }
}