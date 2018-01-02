using System.Collections.Generic;
using System.Linq;

namespace xyj.core.Models.Service
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
