
using Frank.Model;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Linq.Dynamic;

namespace Frank.Service.Common
{
    public class PageListResultBO<T> where T : class
    {
        public List<T> ListItem { get; set; }
        public int Count { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
    }
    public class PageListResultBOV2<T> where T : class
    {
        public List<T> data { get; set; }
        public int recordsTotal { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int recordsFiltered { get; set; }
        public int draw { get; set; }
        public string error { get; set; }

    }
    public class DataTableAjaxPostModel
    {
        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order1> order { get; set; }
    }

    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }
    }

    public class Search
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class Order1
    {
        public int column { get; set; }
        public string dir { get; set; }
    }

    public static class PagedListExt
    {
        public static PageListResultBO<TSource>
            ToCustomPagedList<TSource>(this IQueryable<TSource> query, int pageIndex = 1, int pageSize = 20, string customOrder = "") where TSource : Entity<long>
        {
            query = query.GroupBy(q => q.Id).Select(q => q.FirstOrDefault()).OrderByDescending(q => q.Id);
            if (string.IsNullOrEmpty(customOrder) == false)
            {
                query = query.OrderBy(customOrder);
            }
            var resultmodel = new PageListResultBO<TSource>();
            if (pageSize == -1)
            {
                var dataPageList = query.ToList();
                resultmodel.Count = dataPageList.Count;
                resultmodel.TotalPage = 1;
                resultmodel.ListItem = dataPageList;
            }
            else
            {
                var dataPageList = query.ToPagedList(pageIndex, pageSize);
                resultmodel.Count = dataPageList.TotalItemCount;
                resultmodel.TotalPage = dataPageList.PageCount;
                resultmodel.ListItem = dataPageList.ToList();
            }
            return resultmodel;
        }
    }

}
