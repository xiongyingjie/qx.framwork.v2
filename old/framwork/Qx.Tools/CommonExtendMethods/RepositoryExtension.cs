using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Qx.Tools.CommonExtendMethods
{
    public static class RepositoryExtension
    {
        public static List<T> NoTrackingWhere<T>(this DbSet<T> dbSet, Func<T, bool> filter) where T : class
        {
            return dbSet.AsNoTracking().Where(filter).ToList();
        }

        public static T NoTrackingFind<T>(this DbSet<T> dbSet, Func<T, bool> filter) where T : class
        {
            return dbSet.AsNoTracking().FirstOrDefault(filter);
        }

        public static List<T> NoTrackingToList<T>(this DbSet<T> dbSet) where T : class
        {
            return dbSet.AsNoTracking().ToList();
        }
    }
}