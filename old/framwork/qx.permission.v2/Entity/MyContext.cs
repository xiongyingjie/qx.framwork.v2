using System.Data.Entity;
using qx.permmision.v2.Configs;

namespace qx.permmision.v2.Entity
{
    public partial class MyContext : DbContext
    {
        public MyContext()
            : base((string) Setting.ConnectionString)
        {
        }
        public virtual DbSet<button> button { get; set; }
        public virtual DbSet<data_filter> data_filter { get; set; }
        public virtual DbSet<filter_script> filter_script { get; set; }
        public virtual DbSet<menu> menu { get; set; }
        public virtual DbSet<organization_level> organization_level { get; set; }
        public virtual DbSet<organization_relation> organization_relation { get; set; }
        public virtual DbSet<orgnization> orgnization { get; set; }
        public virtual DbSet<orgnization_position> orgnization_position { get; set; }
        public virtual DbSet<orgnization_type> orgnization_type { get; set; }
        public virtual DbSet<permission_user> permission_user { get; set; }
        public virtual DbSet<position> position { get; set; }
        public virtual DbSet<position_type> position_type { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<role_button_forbid> role_button_forbid { get; set; }
        public virtual DbSet<role_group> role_group { get; set; }
        public virtual DbSet<role_group_relation> role_group_relation { get; set; }
        public virtual DbSet<role_menu> role_menu { get; set; }
        public virtual DbSet<user_group> user_group { get; set; }
        public virtual DbSet<user_group_relation> user_group_relation { get; set; }
        public virtual DbSet<user_group_role_group_relation> user_group_role_group_relation { get; set; }
        public virtual DbSet<user_group_role_relation> user_group_role_relation { get; set; }
        public virtual DbSet<user_orgnization> user_orgnization { get; set; }
        public virtual DbSet<user_position> user_position { get; set; }
        public virtual DbSet<user_role> user_role { get; set; }
        public virtual DbSet<user_type> user_type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<button>()
                .Property(e => e.button_id)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.menu_id)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<data_filter>()
                .Property(e => e.data_filter_id)
                .IsUnicode(false);

            modelBuilder.Entity<data_filter>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<data_filter>()
                .Property(e => e.report_id)
                .IsUnicode(false);

            modelBuilder.Entity<data_filter>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<data_filter>()
                .Property(e => e.filter_script_id)
                .IsUnicode(false);

            modelBuilder.Entity<filter_script>()
                .Property(e => e.filter_script_id)
                .IsUnicode(false);

            modelBuilder.Entity<filter_script>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<filter_script>()
                .Property(e => e.script)
                .IsUnicode(false);

            modelBuilder.Entity<filter_script>()
                .Property(e => e.note)
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

            modelBuilder.Entity<organization_level>()
                .Property(e => e.organization_level_id)
                .IsUnicode(false);

            modelBuilder.Entity<organization_level>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<organization_level>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<organization_relation>()
                .Property(e => e.organization_relation_id)
                .IsUnicode(false);

            modelBuilder.Entity<organization_relation>()
                .Property(e => e.orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<organization_relation>()
                .Property(e => e.other_orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.father_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.descripe)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.orgnization_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.sub_system)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .Property(e => e.organization_level_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization>()
                .HasMany(e => e.organization_relation)
                .WithRequired(e => e.orgnization)
                .HasForeignKey(e => e.orgnization_id);

            modelBuilder.Entity<orgnization>()
                .HasMany(e => e.organization_relation1)
                .WithRequired(e => e.orgnization1)
                .HasForeignKey(e => e.other_orgnization_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<orgnization_position>()
                .Property(e => e.orgnization_position_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization_position>()
                .Property(e => e.orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization_position>()
                .Property(e => e.position_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization_type>()
                .Property(e => e.orgnization_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization_type>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<orgnization_type>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.nick_name)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.user_pwd)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.user_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .Property(e => e.position_id)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .Property(e => e.position_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .Property(e => e.descripe)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<position_type>()
                .Property(e => e.position_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<position_type>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<position_type>()
                .Property(e => e.father_id)
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

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.role_Button_forbid_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.button_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<role_group>()
                .Property(e => e.role_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_group>()
                .Property(e => e.role_group_name)
                .IsUnicode(false);

            modelBuilder.Entity<role_group>()
                .Property(e => e.father_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.role_group_relation_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.role_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.role_name)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.create_userid)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.create_username)
                .IsUnicode(false);

            modelBuilder.Entity<role_group_relation>()
                .Property(e => e.create_Date)
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

            modelBuilder.Entity<user_group>()
                .Property(e => e.user_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group>()
                .Property(e => e.user_group_name)
                .IsUnicode(false);

            modelBuilder.Entity<user_group>()
                .Property(e => e.father_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.user_group_relation_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.nick_name)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.user_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.create_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.create_user_name)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_relation>()
                .Property(e => e.create_date)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_group_relation>()
                .Property(e => e.user_group_role_group_relation_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_group_relation>()
                .Property(e => e.user_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_group_relation>()
                .Property(e => e.role_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_group_relation>()
                .Property(e => e.create_date)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_group_relation>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_relation>()
                .Property(e => e.user_group_role_relation_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_relation>()
                .Property(e => e.user_group_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_relation>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_relation>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<user_group_role_relation>()
                .Property(e => e.create_date)
                .IsUnicode(false);

            modelBuilder.Entity<user_orgnization>()
                .Property(e => e.user_orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_orgnization>()
                .Property(e => e.orgnization_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_orgnization>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_position>()
                .Property(e => e.user_position_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_position>()
                .Property(e => e.orgnization_position_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_position>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.user_role_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.role_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<user_type>()
                .Property(e => e.user_type_id)
                .IsUnicode(false);

            modelBuilder.Entity<user_type>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
