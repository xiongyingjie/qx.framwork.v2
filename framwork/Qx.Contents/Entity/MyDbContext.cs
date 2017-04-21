using System.Data.Entity;
using Qx.Contents.Configs;

namespace Qx.Contents.Entity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base((string) Setting.ConnectionString)
        {
        }

        public virtual DbSet<column_design> column_design { get; set; }
        public virtual DbSet<conlumn_type> conlumn_type { get; set; }
        public virtual DbSet<content_column_design> content_column_design { get; set; }
        public virtual DbSet<content_column_value> content_column_value { get; set; }
        public virtual DbSet<content_table_design> content_table_design { get; set; }
        public virtual DbSet<content_table_query> content_table_query { get; set; }
        public virtual DbSet<content_type> content_type { get; set; }
        public virtual DbSet<data_type> data_type { get; set; }
        public virtual DbSet<library> library { get; set; }
        public virtual DbSet<page_control_type> page_control_type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<column_design>()
                .Property(e => e.ColumnDesignID)
                .IsUnicode(false);

            modelBuilder.Entity<column_design>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<column_design>()
                .Property(e => e.UnitID)
                .IsUnicode(false);

            modelBuilder.Entity<column_design>()
                .Property(e => e.UpdateTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<column_design>()
                .Property(e => e.HtmlTemplate)
                .IsUnicode(false);

            modelBuilder.Entity<column_design>()
                .Property(e => e.HtmlTemplateParams)
                .IsUnicode(false);

            modelBuilder.Entity<conlumn_type>()
                .Property(e => e.ColumnTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<conlumn_type>()
                .Property(e => e.ColumnTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.CCD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.CTD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.DT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.PCT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.ColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.Seq)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.IsPk)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.DefValue)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_value>()
                .Property(e => e.CCV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_value>()
                .Property(e => e.CCD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_value>()
                .Property(e => e.ColumnValue)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_value>()
                .Property(e => e.RelationKeyValue)
                .IsUnicode(false);

            modelBuilder.Entity<content_table_design>()
                .Property(e => e.CTD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<content_table_design>()
                .Property(e => e.CT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<content_table_design>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<content_table_design>()
                .HasMany(e => e.content_column_design)
                .WithOptional(e => e.content_table_design)
                .WillCascadeOnDelete();

            modelBuilder.Entity<content_table_design>()
                .HasMany(e => e.content_table_query)
                .WithOptional(e => e.content_table_design)
                .WillCascadeOnDelete();

            modelBuilder.Entity<content_table_query>()
                .Property(e => e.CTQ_ID)
                .IsUnicode(false);

            modelBuilder.Entity<content_table_query>()
                .Property(e => e.CTD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<content_table_query>()
                .Property(e => e.SqlQuery)
                .IsUnicode(false);

            modelBuilder.Entity<content_type>()
                .Property(e => e.CT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<content_type>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<content_type>()
                .Property(e => e.FatherID)
                .IsUnicode(false);

            modelBuilder.Entity<content_type>()
                .HasMany(e => e.content_table_design)
                .WithOptional(e => e.content_type)
                .WillCascadeOnDelete();

            modelBuilder.Entity<data_type>()
                .Property(e => e.DT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<data_type>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<data_type>()
                .HasMany(e => e.content_column_design)
                .WithOptional(e => e.data_type)
                .WillCascadeOnDelete();

            modelBuilder.Entity<page_control_type>()
                .Property(e => e.PCT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<page_control_type>()
                .Property(e => e.PCT_Name)
                .IsUnicode(false);

            modelBuilder.Entity<page_control_type>()
                .HasMany(e => e.content_column_design)
                .WithOptional(e => e.page_control_type)
                .WillCascadeOnDelete();
        }
    }
}