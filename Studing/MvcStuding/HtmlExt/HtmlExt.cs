using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcStuding.HtmlExt
{
    public static class HtmlExt
    {
        /// <summary>
        /// Radio枚举
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="valueEnum"></param>
        /// <param name="selectedValue"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString RadioEnum(this HtmlHelper helper, string name, Enum valueEnum, string selectedValue = null, object htmlAttributes = null)
        {
            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("radio");
            divBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            foreach (var value in Enum.GetValues(valueEnum.GetType()))
            {
                object[] objAttrs = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objAttrs != null &&
                    objAttrs.Length > 0)
                {
                    int intValue = (int)value;
                    DescriptionAttribute descAttr = objAttrs[0] as DescriptionAttribute;
                    divBuilder.InnerHtml += string.Format("<label><input type='radio' value='{0}' name='{1}' id='{1}{2}' {3}/>{4}</label>",
                        intValue,
                        name,
                        intValue,
                        selectedValue == intValue.ToString() ? "checked" : "",
                        descAttr.Description);
                }

            }
            return new MvcHtmlString(divBuilder.ToString());
        }
    }
}