using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStuding.Models
{
    public class ProductModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Product model = bindingContext.Model as Product ?? new Product();
            model.Title = GetValue(bindingContext, "Title");
            model.CreateTime = DateTime.Now.ToShortDateString();
            //model.Others = new OtherInfo()
            //{
            //    Price = 1000,
            //    StartCity = "上海"
            //};
            return model;
        }
        private string GetValue(ModelBindingContext context, string name)
        {
            //name = (context.ModelName == "" ? "" : context.ModelName + ".") + name;
            ValueProviderResult result = context.ValueProvider.GetValue(name);
            if (result == null || result.AttemptedValue == "")
                return "无标题";
            else
                return (string)result.AttemptedValue;
        }
    }
}