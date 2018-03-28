namespace xyj.tool.Entity
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
        public virtual DbSet<menu> menu { get; set; }
        public virtual DbSet<role_menu> role_menu { get; set; }
        public virtual DbSet<report_data> report_data { get; set; }
        public virtual DbSet<role> role { get; set; }

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
            modelBuilder.Entity<menu>()
              .Property(e => e.menu_id)
              .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.farther_id)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.depth)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.sub_system)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.controller)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.action)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.area)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.image_class)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.active_li)
                .IsUnicode(false);

            modelBuilder.Entity<role_menu>()
                .Property(e => e.role_menu_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_menu>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_menu>()
                .Property(e => e.menu_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_menu>()
                .Property(e => e.note)
                .IsUnicode(false);
            modelBuilder.Entity<role>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.role_type)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.sub_system)
                .IsUnicode(false);
        }
    }
}
