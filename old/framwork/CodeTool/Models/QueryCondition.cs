using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xyj.tool.Models
{
    public class QueryCondition
    {
        public QueryTypeEnum QueryType;
        public string ColumName;
        public string ColumNote;
        public string TableName;

        public bool CanQuery
        {
            get { return QueryTypeEnum.None != QueryType; }
        }
        public string ToString(int count)
        {
            var dest = TableName+"."+ColumName;
            switch (QueryType)
            {
                case QueryTypeEnum.None:
                    {
                        return "";
                    }
                case QueryTypeEnum.Like:
                    {
                        return string.Format("({0}.{1} like '%{{{2}}}%' or {0}.{1} is null) ", TableName,ColumName,count);
                    }

                case QueryTypeEnum.Equal:
                    {
                        dest += " = ";
                    }
                    break;
                case QueryTypeEnum.Greater:
                    {
                        dest += " > ";
                    }
                    break;
                case QueryTypeEnum.Lower:
                    {
                        dest += " < ";
                    }
                    break;
                case QueryTypeEnum.NotEqual:
                    {
                        dest += " <> ";
                    }
                    break;
            }
            dest += "'{" + count + "}' ";
            return dest;
        }
        public string ToJsString(int count)
        {
            var dest = TableName + "." + ColumName;
            switch (QueryType)
            {
                case QueryTypeEnum.None:
                    {
                        return "";
                    }
                case QueryTypeEnum.Like:
                {
                    return ".lk";
                }

                case QueryTypeEnum.Equal:
                {
                    dest += ".eq";
                }
                    break;
                case QueryTypeEnum.Greater:
                {
                    dest += ".bg";
                }
                    break;
                case QueryTypeEnum.Lower:
                {
                    dest += ".ls";
                }
                    break;
                case QueryTypeEnum.NotEqual:
                    {
                        dest += ".neq";
                    }
                    break;
            }
            dest += "('" + ColumName + "' ,'{" + count + "}') ";
            return dest;
        }
    }
}
