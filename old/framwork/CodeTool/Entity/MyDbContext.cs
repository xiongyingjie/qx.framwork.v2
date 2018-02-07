namespace CodeTool.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=sys.core")
        {
        }

        public virtual DbSet<report_data> report_data { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<report_data>()
                .Property(e => e.ReportID)
                .IsUnicode(false);

            modelBuilder.Entity<report_data>()
                .Property(e => e.ReportName)
                .IsUnicode(false);

            modelBuilder.Entity<report_data>()
                .Property(e => e.SqlStr)
                .IsUnicode(false);

            modelBuilder.Entity<report_data>()
                .Property(e => e.HeadFields)
                .IsUnicode(false);

            modelBuilder.Entity<report_data>()
                .Property(e => e.ParaNames)
                .IsUnicode(false);

            modelBuilder.Entity<report_data>()
                .Property(e => e.ColunmToShow)
                .IsUnicode(false);

            modelBuilder.Entity<report_data>()
                .Property(e => e.OperateColum)
                .IsUnicode(false);

            modelBuilder.Entity<report_data>()
                .Property(e => e.ReportLog)
                .IsUnicode(false);
        }
    }
}
