
using Microsoft.EntityFrameworkCore;
using xyj.study;
using xyj.core.Utility;
namespace xyj.study.Entity
{
 public partial class MyContext : DbContext
    {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbUtility.SqlSeverConnString("sys.core"));
        }
        
public virtual DbSet<student> student { get; set; }
public virtual DbSet<course> course { get; set; }
public virtual DbSet<Class> Class { get; set; }
public virtual DbSet<student_class> student_class { get; set; }
public virtual DbSet<class_course> class_course { get; set; }
public virtual DbSet<metting_room> metting_room { get; set; }
public virtual DbSet<medicare_card> medicare_card { get; set; }
public virtual DbSet<metting_room_state> metting_room_state { get; set; }
public virtual DbSet<metting_order_state> metting_order_state { get; set; }
public virtual DbSet<metting_order_time_span> metting_order_time_span { get; set; }
public virtual DbSet<metting_order> metting_order { get; set; }
public virtual DbSet<sub_system_data> sub_system_data { get; set; }
public virtual DbSet<orgnization_type> orgnization_type { get; set; }
public virtual DbSet<organization_level> organization_level { get; set; }
public virtual DbSet<sub_system_reg> sub_system_reg { get; set; }
public virtual DbSet<orgnization> orgnization { get; set; }
public virtual DbSet<role_button_forbid> role_button_forbid { get; set; }
public virtual DbSet<role_group> role_group { get; set; }
public virtual DbSet<user_group> user_group { get; set; }
public virtual DbSet<role_group_relation> role_group_relation { get; set; }
public virtual DbSet<user_type> user_type { get; set; }
public virtual DbSet<permission_user> permission_user { get; set; }
public virtual DbSet<button> button { get; set; }
public virtual DbSet<menu> menu { get; set; }
public virtual DbSet<sub_system_data_log> sub_system_data_log { get; set; }
public virtual DbSet<role_menu> role_menu { get; set; }
public virtual DbSet<user_orgnization> user_orgnization { get; set; }
public virtual DbSet<user_group_role_group_relation> user_group_role_group_relation { get; set; }
public virtual DbSet<user_role> user_role { get; set; }
public virtual DbSet<user_group_relation> user_group_relation { get; set; }
public virtual DbSet<filter_script> filter_script { get; set; }
public virtual DbSet<data_filter> data_filter { get; set; }
public virtual DbSet<orgnization_position> orgnization_position { get; set; }
public virtual DbSet<organization_relation> organization_relation { get; set; }
public virtual DbSet<position_type> position_type { get; set; }
public virtual DbSet<position> position { get; set; }
public virtual DbSet<sub_system> sub_system { get; set; }
public virtual DbSet<role> role { get; set; }
public virtual DbSet<user_position> user_position { get; set; }
public virtual DbSet<user_group_role_relation> user_group_role_relation { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
  }
}
