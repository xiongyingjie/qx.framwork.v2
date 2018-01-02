
using Microsoft.EntityFrameworkCore;
using Qx.Contents.Configs;

namespace Qx.Contents.Entity
{
    public class ContentsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(Setting.ConnectionString);
        }
        public virtual DbSet<column_design> column_design { get; set; }
        public virtual DbSet<column_tempelate> column_tempelate { get; set; }
        public virtual DbSet<conlumn_type> conlumn_type { get; set; }
        public virtual DbSet<content_column_design> content_column_design { get; set; }
        public virtual DbSet<content_column_value> content_column_value { get; set; }
        public virtual DbSet<content_table_design> content_table_design { get; set; }
        public virtual DbSet<content_table_query> content_table_query { get; set; }
        public virtual DbSet<content_type> content_type { get; set; }
        public virtual DbSet<data_type> data_type { get; set; }
        public virtual DbSet<librarys> librarys { get; set; }
        public virtual DbSet<page_control_type> page_control_type { get; set; }
        public virtual DbSet<content_column_ui_design> content_column_ui_design { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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

            modelBuilder.Entity<column_tempelate>()
                .Property(e => e.column_tempelate_html)
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
                .HasMany(e => e.content_table_query)
                ;

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
                .HasMany(e => e.content_table_design);

            modelBuilder.Entity<data_type>()
                .Property(e => e.dt_id)
                .IsUnicode(false);

            modelBuilder.Entity<data_type>()
                .Property(e => e.type_name)
                .IsUnicode(false);

            modelBuilder.Entity<data_type>()
                .HasMany(e => e.content_column_design);

            modelBuilder.Entity<page_control_type>()
                .Property(e => e.pct_id)
                .IsUnicode(false);

            modelBuilder.Entity<page_control_type>()
                .Property(e => e.pct_name)
                .IsUnicode(false);

            modelBuilder.Entity<page_control_type>()
                .HasMany(e => e.content_column_design);

            modelBuilder.Entity<content_column_ui_design>()
                .Property(e => e.ccud_id)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_ui_design>()
                .Property(e => e.tip)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_ui_design>()
                .Property(e => e.validators)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_ui_design>()
                .Property(e => e.options)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_ui_design>()
                .Property(e => e.width)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_ui_design>()
                .Property(e => e.height)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_ui_design>()
                .Property(e => e.folder)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_ui_design>()
                .Property(e => e.submitUrl)
                .IsUnicode(false);

            modelBuilder.Entity<content_column_ui_design>()
                .Property(e => e.color)
                .IsUnicode(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}