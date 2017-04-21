using Qx.Permission.Configs;

namespace Qx.Permission.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyContext : DbContext
    {
        public MyContext()
            : base(Setting.ConnectionString)
        {
        }

        public virtual DbSet<button> button { get; set; }
        public virtual DbSet<menu> menu { get; set; }
        public virtual DbSet<menu_extension> menu_extension { get; set; }
        public virtual DbSet<permission_user> permission_user { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<role_button_forbid> role_button_forbid { get; set; }
        public virtual DbSet<role_menu> role_menu { get; set; }
        public virtual DbSet<user_role> user_role { get; set; }
        public virtual DbSet<user_type> user_type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<button>()
                .Property(e => e.ButtonID)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.MenuID)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<button>()
                .Property(e => e.Note)
                .IsFixedLength();

            modelBuilder.Entity<button>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.MenuID)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.FartherID)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.Note)
                .IsFixedLength();

            modelBuilder.Entity<menu>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .HasOptional(e => e.menu_extension)
                .WithRequired(e => e.menu)
                .WillCascadeOnDelete();

            modelBuilder.Entity<menu_extension>()
                .Property(e => e.MenuID)
                .IsUnicode(false);

            modelBuilder.Entity<menu_extension>()
                .Property(e => e.Controller)
                .IsUnicode(false);

            modelBuilder.Entity<menu_extension>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<menu_extension>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<menu_extension>()
                .Property(e => e.ImageClass)
                .IsUnicode(false);

            modelBuilder.Entity<menu_extension>()
                .Property(e => e.ActiveLi)
                .IsUnicode(false);

            modelBuilder.Entity<menu_extension>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<menu_extension>()
                .Property(e => e.ParentId)
                .IsUnicode(false);

            modelBuilder.Entity<menu_extension>()
                .Property(e => e.IsParent)
                .IsUnicode(false);

            modelBuilder.Entity<menu_extension>()
                .Property(e => e.SubSystem)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.UserPwd)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.UserTypeId)
                .IsUnicode(false);

            modelBuilder.Entity<permission_user>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.RoleType)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.subSystem)
                .IsUnicode(false);

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.RoleButtonForbidID)
                .IsUnicode(false);

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.ButtonID)
                .IsUnicode(false);

            modelBuilder.Entity<role_button_forbid>()
                .Property(e => e.Note)
                .IsFixedLength();

            modelBuilder.Entity<role_menu>()
                .Property(e => e.RoleMenuID)
                .IsUnicode(false);

            modelBuilder.Entity<role_menu>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<role_menu>()
                .Property(e => e.MenuID)
                .IsUnicode(false);

            modelBuilder.Entity<role_menu>()
                .Property(e => e.Note)
                .IsFixedLength();

            modelBuilder.Entity<user_role>()
                .Property(e => e.UserRoleID)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<user_type>()
                .Property(e => e.UserTypeId)
                .IsUnicode(false);

            modelBuilder.Entity<user_type>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
