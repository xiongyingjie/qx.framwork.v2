using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Tools.Models.Service
{
    public class QueryReult<T>
    {
        public int CurrentPage;
        public int PageSize;
        public int TotalSize;
        public IQueryable<T> PageData;

        public List<T> ToList()
        {
            return PageData.ToList();
        }
    }
}
