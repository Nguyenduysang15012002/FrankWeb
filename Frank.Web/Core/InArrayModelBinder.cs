using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frank.Web.Core
{
    public class InArrayModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value == null || string.IsNullOrEmpty(value.AttemptedValue))
            {
                return null;
            }

            return value
                .AttemptedValue
                .Split(',')
                .ToArray();
        }
    }
}