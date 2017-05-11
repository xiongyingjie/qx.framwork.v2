using System.Data.Entity;
using Qx.Contents.Configs;

namespace Qx.Contents.Entity
{
    public class ContentsContext : DbContext
    {
        public ContentsContext()
            : base((string) Setting.ConnectionString)
        {
        }

        public virtual DbSet<column_tempelate> column_tempelate { get; set; }
        public virtual DbSet<column_design> column_design { get; set; }
        public virtual DbSet<librarys> librarys { get; set; }
        public virtual DbSet<conlumn_type> conlumn_type { get; set; }
        public virtual DbSet<content_column_design> content_column_design { get; set; }
        public virtual DbSet<content_column_value> dontent_column_value { get; set; }
        public virtual DbSet<content_table_design> content_table_design { get; set; }
        public virtual DbSet<content_table_query> content_table_query { get; set; }
        public virtual DbSet<content_type> content_type { get; set; }
        public virtual DbSet<data_type> data_type { get; set; }
        public virtual DbSet<page_control_type> page_control_type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<column_design>()
                .Property(e => e.column_design_id)
                .IsUnicode(false);

            modelBuilder.Entity<column_design>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<column_design>()
                .Property(e => e.unit_id)
                .IsUnicode(false);

            modelBuilder.Entity<column_design>()
                .Property(e => e.update_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<column_design>()
                .Property(e => e.html_template)
                .IsUnicode(false);

            modelBuilder.Entity<column_design>()
                .Property(e => e.html_template_params)
                .IsUnicode(false);

            modelBuilder.Entity<conlumn_type>()
                .Property(e => e.column_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<conlumn_type>()
                .Property(e => e.column_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.ccd_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.ctd_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.dt_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.pct_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.column_name)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.seq)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.is_pk)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_design>()
                .Property(e => e.def_value)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_value>()
                .Property(e => e.ccv_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_value>()
                .Property(e => e.ccd_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_value>()
                .Property(e => e.column_value)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_value>()
                .Property(e => e.relation_key_value)
                .IsUnicode(false);

            modelBuilder.Entity<content_table_design>()
                .Property(e => e.ctd_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_table_design>()
                .Property(e => e.ct_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_table_design>()
                .Property(e => e.table_name)
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
                .Property(e => e.ctq_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_table_query>()
                .Property(e => e.ctd_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_table_query>()
                .Property(e => e.sql_query)
                .IsUnicode(false);

            modelBuilder.Entity<content_type>()
                .Property(e => e.ct_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_type>()
                .Property(e => e.type_name)
                .IsUnicode(false);

            modelBuilder.Entity<content_type>()
                .Property(e => e.father_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_type>()
                .HasMany(e => e.content_table_design)
                .WithOptional(e => e.content_type)
                .WillCascadeOnDelete();

            modelBuilder.Entity<data_type>()
                .Property(e => e.dt_id)
                .IsUnicode(false);

            modelBuilder.Entity<data_type>()
                .Property(e => e.type_name)
                .IsUnicode(false);

            modelBuilder.Entity<data_type>()
                .HasMany(e => e.content_column_design)
                .WithOptional(e => e.data_type)
                .WillCascadeOnDelete();

            modelBuilder.Entity<page_control_type>()
                .Property(e => e.pct_id)
                .IsUnicode(false);

            modelBuilder.Entity<page_control_type>()
                .Property(e => e.pct_name)
                .IsUnicode(false);

            modelBuilder.Entity<page_control_type>()
                .HasMany(e => e.content_column_designs)
                .WithOptional(e => e.page_control_type)
                .WillCascadeOnDelete();
        }
    }
}