using Microsoft.EntityFrameworkCore;
using xyj.core;
using xyj.core.Utility;

namespace xyj.study.Entity
{
    public partial class MyContext : DbContext
    {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(DbUtility.SqlSeverConnString("xyj.study"));
        }
        public virtual DbSet<site> site { get; set; }

        public virtual DbSet<site_page> site_page { get; set; }
        public virtual DbSet<site_log> site_log { get; set; }

        
    }
}
