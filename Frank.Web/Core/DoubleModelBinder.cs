using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frank.Web.Core
{
    public class DoubleModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == null || valueProviderResult.AttemptedValue == null || valueProviderResult.AttemptedValue == "null")
            {
                return null;
            }

            return (valueProviderResult != null && string.IsNullOrEmpty(valueProviderResult.AttemptedValue)) ? base.BindModel(controllerContext, bindingContext) : Convert.ToDouble(valueProviderResult.AttemptedValue.Replace(".", ","));
            // of course replace with your custom conversion logic
        }
    }
}