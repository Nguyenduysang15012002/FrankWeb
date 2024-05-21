
using Frank.Service.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Frank.Model.Common;



namespace Frank.Service.Common
{
    public static class ConstantExtension
    {
        public static ShowStatusDto GetStatusInfo<TConst>(string value)
        {
            var rs = new ShowStatusDto();
            rs.Code = value;

            var listProperty = typeof(TConst).GetProperties();
            if (listProperty != null)
            {
                foreach (var item in listProperty)
                {
                    if (item.GetGetMethod().IsStatic)
                    {
                        var val = item.GetValue(null).ToString();
                        var name = item.GetAttribute<DisplayNameAttribute>(true).DisplayName;
                        if (val == value)
                        {
                            rs.Name = name;
                        }

                        var getObjColor = item.GetAttribute<ColorAttribute>(false);
                        if (val == value && getObjColor != null)
                        {
                            rs.Color = getObjColor.Color;
                            rs.BgColor = getObjColor.BgColor;
                            rs.Icon = getObjColor.Icon;
                        }
                    }
                }
            }
            return rs;
        }
        /// <summary>
        /// Lấy danh sách dropdownlist constant theo class
        /// </summary>
        /// <typeparam name="TConst"></typeparam>
        /// <param name="selectedItem"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetDropdownData<TConst>(string selectedItem = null)
        {
            var result = new List<SelectListItem>();
            var listProperty = typeof(TConst).GetProperties();
            if (listProperty != null)
            {
                foreach (var item in listProperty)
                {
                    if (item.GetGetMethod().IsStatic)
                    {
                        var val = item.GetValue(null).ToString();
                        var name = item.GetAttribute<DisplayNameAttribute>(true).DisplayName;
                        result.Add(new SelectListItem()
                        {
                            Text = name,
                            Value = val,
                            Selected = !string.IsNullOrEmpty(selectedItem) ? val == selectedItem : false
                        });
                    }
                }
            }
            return result;
        }

        public static List<SelectListItem> GetDropdownDataMultiple<TConst>(List<string> selectedItem = null)
        {
            var result = new List<SelectListItem>();
            var listProperty = typeof(TConst).GetProperties();
            if (listProperty != null)
            {
                foreach (var item in listProperty)
                {
                    if (item.GetGetMethod().IsStatic)
                    {
                        var val = item.GetValue(null).ToString();
                        var name = item.GetAttribute<DisplayNameAttribute>(true).DisplayName;
                        result.Add(new SelectListItem()
                        {
                            Text = name,
                            Value = val,
                            Selected = selectedItem != null ? selectedItem.Contains(val) : false
                        });
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Lấy danh sách value constant theo class
        /// </summary>
        /// <typeparam name="TConst"></typeparam>
        /// <param name="selectedItem"></param>
        /// <returns></returns>
        public static List<string> GetListData<TConst>()
        {
            var result = new List<string>();
            var listProperty = typeof(TConst).GetProperties();
            if (listProperty != null)
            {
                foreach (var item in listProperty)
                {
                    if (item.GetGetMethod().IsStatic)
                    {
                        var val = item.GetValue(null).ToString();
                        var name = item.GetAttribute<DisplayNameAttribute>(true).DisplayName;
                        result.Add(val);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Lấy Tên của constant đề hiển thị
        /// </summary>
        /// <typeparam name="TConst"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>

        public static string GetName<TConst>(string value)
        {
            var listProperty = typeof(TConst).GetProperties();
            if (listProperty != null)
            {
                foreach (var item in listProperty)
                {
                    if (item.GetGetMethod().IsStatic)
                    {
                        var val = item.GetValue(null).ToString();
                        var name = item.GetAttribute<DisplayNameAttribute>(true).DisplayName;
                        if (val == value)
                        {
                            return name;
                        }
                    }
                }
            }
            return string.Empty;
        }
        public static string GetValueByName<TConst>(string name)
        {
            var listProperty = typeof(TConst).GetProperties();
            if (listProperty != null)
            {
                foreach (var item in listProperty)
                {
                    if (item.GetGetMethod().IsStatic)
                    {
                        var val = item.GetValue(null).ToString();
                        var name1 = item.GetAttribute<DisplayNameAttribute>(true).DisplayName;
                        if (name1 == name)
                        {
                            return val;
                        }
                    }
                }
            }
            return string.Empty;
        }
        public static string GetColor<TConst>(string value)
        {
            var listProperty = typeof(TConst).GetProperties();
            if (listProperty != null)
            {
                foreach (var item in listProperty)
                {
                    if (item.GetGetMethod().IsStatic)
                    {
                        var val = item.GetValue(null).ToString();
                        var getObj = item.GetAttribute<ColorAttribute>(false);
                        if (val == value && getObj != null)
                        {
                            return getObj.Color;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static string GetBackgroundColor<TConst>(string value)
        {
            var listProperty = typeof(TConst).GetProperties();
            if (listProperty != null)
            {
                foreach (var item in listProperty)
                {
                    if (item.GetGetMethod().IsStatic)
                    {
                        var val = item.GetValue(null).ToString();
                        var getObj = item.GetAttribute<ColorAttribute>(false);
                        if (val == value && getObj != null)
                        {
                            return getObj.BgColor;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static string GetDisplayNameById<TConst>(string value)
        {
            var listProperty = typeof(TConst).GetProperties();
            if (listProperty != null)
            {
                foreach (var item in listProperty)
                {
                    if (item.GetGetMethod().IsStatic)
                    {
                        var val = item.GetValue(null).ToString();
                        var name = item.GetAttribute<DisplayNameAttribute>(true).DisplayName;
                        if (val == value)
                        {
                            return name;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static string GetConstantName<TConst>(string value)
        {
            var listProperty = typeof(TConst).GetProperties();
            if (listProperty != null)
            {
                foreach (var item in listProperty)
                {
                    if (item.GetGetMethod().IsStatic)
                    {
                        var val = item.GetValue(null).ToString();
                        var getObj = item.GetMethod.Name;
                        if (val == value && getObj != null)
                        {
                            getObj = getObj.Replace("get_", "");
                            return getObj;
                        }
                    }
                }
            }
            return string.Empty;
        }

        internal static object GetName<T>()
        {
            throw new NotImplementedException();
        }

        public static List<SelectListItem> GetCustomDisplayDropdownData<TConst>(string selectedItem = null)
        {
            var result = new List<SelectListItem>();
            var listProperty = typeof(TConst).GetProperties();
            if (listProperty != null)
            {
                foreach (var item in listProperty)
                {
                    if (item.GetGetMethod().IsStatic)
                    {
                        var val = item.GetValue(null).ToString();
                        var name = item.GetAttribute<CustomDisplayNameAttribute>(true).Text;
                        result.Add(new SelectListItem()
                        {
                            Text = name,
                            Value = val,
                            Selected = !string.IsNullOrEmpty(selectedItem) ? val == selectedItem : false
                        });
                    }
                }
            }
            return result;
        }

        public static List<(string, string)> GetDisplayNameAndValue<T>()
        {
            var result = new List<(string, string)>();

            var properties = typeof(T).GetProperties();

            if (properties != null && properties.Length > 0)
            {
                foreach (var item in properties)
                {
                    DisplayNameAttribute displayNameAttribute = item.GetCustomAttribute<DisplayNameAttribute>(true);
                    string displayName = displayNameAttribute.DisplayName;
                    string value = item.GetValue(null).ToString();
                    result.Add((displayName, value));
                }
            }


            return result;
        }

        public static List<(string, string, string)> GetDisplayNameAndValueAndColor<T>()
        {
            var result = new List<(string, string, string)>();

            var properties = typeof(T).GetProperties();

            if (properties != null && properties.Length > 0)
            {
                foreach (var item in properties)
                {
                    DisplayNameAttribute displayNameAttribute = item.GetCustomAttribute<DisplayNameAttribute>(true);
                    string displayName = displayNameAttribute.DisplayName;
                    string value = item.GetValue(null).ToString();
                    var getObj = item.GetAttribute<ColorAttribute>(false);
                    string color = getObj.BgColor;
                    result.Add((displayName, value, color));
                }
            }


            return result;
        }
    }
}
