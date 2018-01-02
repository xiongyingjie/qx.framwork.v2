using System;
using System.Collections.Generic;
using System.Linq;

namespace xyj.core.Extensions
{
    public static class ListStringExtension
    {

       
        public static List<List<string>> RemoveCol(this List<List<string>> rows, int colIndex)
        {
            var dest = new List<List<string>>();
            for (var i = 0; i < rows.Count; i++)
            {
                var newRow = new List<string>();
                for (var j = 0; j < rows[i].Count; j++)
                {
                    if (j != colIndex)
                    {
                        newRow.Add(rows[i][j]);
                    }
                }
                dest.Add(newRow);
            }
            return dest;
        }

        public static List<List<string>> AddCol(this List<List<string>> rows, List<string> col)
        {
            if (rows.Count != col.Count)
                throw new Exception("待插入的列的个数与原有行数不匹配");
            var dest = new List<List<string>>();
            for (var i = 0; i < rows.Count; i++)
            {
                var newRow = new List<string>();
                newRow.AddRange(rows[i]);
                newRow.Add(col[i]);
                dest.Add(newRow);
            }
            return dest;
        }

        public static List<List<string>> AddRow(this List<List<string>> rows, List<string> row)
        {
            if (rows.Count > 0 && rows[0].Count != row.Count)
                throw new Exception("待插入的行的列数与原有列数不匹配");
            rows.Add(row);
            return rows;
        }

        public static List<List<string>> AddRowToFirst(this List<List<string>> rows, List<string> row)
        {
            if (rows.Count > 0 && rows[0].Count != row.Count)
                throw new Exception("待插入的行的列数与原有列数不匹配");
            rows.Insert(0, row);
            return rows;
        }

        public static List<List<string>> FilterRows(this List<List<string>> rows, List<string> indexToShow)
        {
            return rows.Select(row => FilterRow(row, indexToShow)).ToList();
        }

     

        public static string ToString(this List<string> list, string splitFlag = " ")
        {
            var dest = "";
            list.ForEach(item => { dest += item + splitFlag; });
            return dest;
        }

        public static List<string> FilterRow(this List<string> row, List<string> indexToShow)
        {
            var dest = new List<string>();

            for (var i = 0; i < row.Count; i++)
            {
                if (indexToShow.Contains(i.ToString()))
                {
                    dest.Add(row[i]);
                }
            }

            return dest;
        }


        public static string PackString(this List<string> srcList, string flag)
        {
            var tempString = "";

            if (srcList.Count > 0) //是否为空,只处理非空
            {
                for (var l = 0; l < srcList.Count; l++)
                {
                    tempString += srcList[l]; //构造认证字符串
                    if (l < srcList.Count - 1)
                    {
                        tempString += flag;
                    }
                }
            }

            return tempString;
        }
        public static string PackString(this List<string> srcList, char flag = ';')
        {
            return PackString(srcList, flag.ToString());
        }

        public static string[] FormatString(this List<string> srcString, char flag = '%')
        {
            return srcString.Select(o => flag + o + flag).ToArray();
        }

        public static List<string> GetDuplicate(this List<string> srcList)
        {
            var temp = new List<string>();
            var duplicated = new List<string>();

            foreach (var item in srcList)
            {
                if (!temp.Contains(item))
                {
                    temp.Add(item);
                }
                else
                {
                    duplicated.Add(item);
                }
            }
            return duplicated;
        }

        public static List<string> DealDuplicate(this List<string> srcList,string flag="")
        {
            if (!flag.HasValue())
            {
                flag = DateTime.Now.Random();
            }
            var dest=new List<string>(srcList);
            var duplicate = dest.GetDuplicate();
            if (duplicate.Any())
            {
                duplicate.ForEach(item =>
                {
                    for (var i = 0; i < dest.Count; i++)
                    {
                        if (dest[i] == item)
                        {
                            dest[i] = item + flag;
                        }
                    }
                });
                //throw new Exception("报表标题中存在重复项:" + duplicate.PackString());
            }
            return dest;
        }
    }
       
}