using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.Utils
{
    public static class EnumToDP
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            Array values = Enum.GetValues(typeof(TEnum));
            List<ListItem> items = new List<ListItem>(values.Length);
            items.AddRange(from object i in values
                           select new ListItem
                           {
                               Text = Enum.GetName(typeof(TEnum), i),
                               Value = i.ToString()
                           });
            return new SelectList(items, "Value", "Text");
        }




    }
}