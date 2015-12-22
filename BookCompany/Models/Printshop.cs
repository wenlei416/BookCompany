using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookCompanyManagement.Models
{
    /// <summary>
    /// 印刷厂实体
    /// </summary>
    public class PrintShop
    {
        [HiddenInput(DisplayValue = false)]
        public int PrintShopId { get; set; }

        [Display(Name = "印厂名称")]
        public string PrintShopName { get; set; }

        [Display(Name = "印厂信息")]
        public string PrintShopDescription { get; set; }
        public bool IsDeleted { get; set; }

        //未入库纸张，来自哪个造纸订单，那个印单消耗了
        //在印的书，来自哪个印单
        //书的库存，来自哪个印单，消耗的送哪去了

        /*-----------造纸订单-----------*/
        public virtual ICollection<PaperMakingOrder> PaperMakingOrders { get; set; }

        /*-----------印书的订单-----------*/
        public virtual ICollection<BookPrintOrder> BookPrintOrders { get; set; }

        /*-----------纸张库存-----------*/
        public virtual ICollection<PaperInstock> PaperInstcoks { get; set; }
        /*-----------书籍库存-----------*/
        public virtual ICollection<BookInstock> BookInstocks { get; set; }


    }
}