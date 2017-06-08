﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Qx.Tools.CommonExtendMethods
{
    public static class ListTExtension
    {

        public static List<T> GetPage<T>(this IQueryable<T> list, int currentPage, int pageSize)
        {
            return list.Take(pageSize * currentPage).Skip(pageSize * (currentPage - 1)).ToList();
        }

        public static List<T> Grap<T>(this List<T> data, int start, int end)
        {
            var dest = new List<T>();
            for (var i = start; i <= end && i < data.Count; i++)
            {
                dest.Add(data[i]);
            }
            return dest;
        }


        public static List<T> GetPage<T>(this List<T> list, int pageIndex, int perCount, out int maxIndex)
        {
            maxIndex = (int)Math.Ceiling(double.Parse(list.Count.ToString()) / perCount);

            var datas = list.ToList();
            var startIndex = perCount * (pageIndex - 1);
            //是否越界
            if (pageIndex <= 0)
                return new List<T>();

            if (startIndex + perCount - 1 < datas.Count)
            {
                return datas.GetRange(startIndex, perCount);
            }
            //是否因为是最后一页而越界               
            if (startIndex < datas.Count)
            {
                return datas.GetRange(startIndex, datas.Count - startIndex);
            }
            return new List<T>();
        }

        public static IEnumerable<T> GetPage<T>(this IEnumerable<T> list, int pageIndex, int perCount, out int maxIndex)
        {
            var datas = list.ToList();
            return datas.GetPage(pageIndex, perCount, out maxIndex);
        }

    }
}