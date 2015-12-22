using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCompanyManagement.Models
{
    public class Makeup
    {
        public int MakeupId { get; set; }
        public string MakeupName { get; set; }
        public MakeupType MakeupType { get; set; }
        public int Count { get; set; }

        /*-----------印书订单----------*/
        public int BookPrintOrderId { get; set; }
        public virtual BookPrintOrder BookPrintOrder { get; set; }

    }
}