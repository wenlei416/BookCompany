using System;
using System.ComponentModel.DataAnnotations;

namespace BookCompanyManagement.Models
{
    public class PaperNeed
    {
        public int PaperNeedId { get; set; }

        /*-----------纸张----------*/
        public int PaperId { get; set; }
        public virtual Paper Paper { get; set; }


        //合计应该是允许小数的
        //用纸的量
        [Display(Name = "合计")]
        public float PaperNeedMount { get; set; }

        [Display(Name = "项目")]
        public PageType PageType { get; set; }

        [Display(Name = "开纸")]
        public int PaperFormat { get; set; }

        [Display(Name = "用料")]
        public float Need { get; set; }

        [Display(Name = "加放")]
        public float PaperWastage { get; set; }

        [Display(Name = "工艺")]
        public String Technological { get; set; }

        /*-----------印书订单----------*/
        public int BookPrintOrderId { get; set; }
        public virtual BookPrintOrder BookPrintOrder { get; set; }



    }
}