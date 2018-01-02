using System.Data.Entity;
using Qx.Msg.Configs;

namespace Qx.Msg.Entity
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
              : base((string) Setting.ConnectionString)
        {
        }


        public virtual DbSet<contact> contact { get; set; }
        public virtual DbSet<crew_limite_type> crew_limite_type { get; set; }
        public virtual DbSet<group_member> group_member { get; set; }
        public virtual DbSet<in_state> in_state { get; set; }
        public virtual DbSet<msg> msg { get; set; }
        public virtual DbSet<msg_collection> msg_collection { get; set; }
        public virtual DbSet<msg_group> msg_group { get; set; }
        public virtual DbSet<msg_send_record> msg_send_record { get; set; }
        public virtual DbSet<msg_type> msg_type { get; set; }
        public virtual DbSet<msg_user> msg_user { get; set; }
        public virtual DbSet<out_state> out_state { get; set; }
        public virtual DbSet<sms_send_record> sms_send_record { get; set; }
        public virtual DbSet<timer_msg> timer_msg { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<contact>()
                .Property(e => e.ContactID)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.OwnerID)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.MembersID)
                .IsUnicode(false);

            modelBuilder.Entity<crew_limite_type>()
                .Property(e => e.CrewLimiteTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<crew_limite_type>()
                .HasMany(e => e.msg_group)
                .WithOptional(e => e.crew_limite_type)
                .WillCascadeOnDelete();

            modelBuilder.Entity<group_member>()
                .Property(e => e.GroupMemberID)
                .IsUnicode(false);

            modelBuilder.Entity<group_member>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<group_member>()
                .Property(e => e.MembersID)
                .IsUnicode(false);

            modelBuilder.Entity<in_state>()
                .Property(e => e.InStateID)
                .IsUnicode(false);

            modelBuilder.Entity<in_state>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<in_state>()
                .HasMany(e => e.msg_send_record)
                .WithOptional(e => e.in_state)
                .WillCascadeOnDelete();

            modelBuilder.Entity<msg>()
                .Property(e => e.MsgID)
                .IsUnicode(false);

            modelBuilder.Entity<msg>()
                .Property(e => e.MsgTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<msg>()
                .Property(e => e.Subjects)
                .IsUnicode(false);

            modelBuilder.Entity<msg>()
                .Property(e => e.Contents)
                .IsUnicode(false);

            modelBuilder.Entity<msg>()
                .Property(e => e.SenderID)
                .IsUnicode(false);

            modelBuilder.Entity<msg>()
                .HasMany(e => e.timer_msg)
                .WithOptional(e => e.msg)
                .WillCascadeOnDelete();

            modelBuilder.Entity<msg_collection>()
                .Property(e => e.MsgCollectionID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_collection>()
                .Property(e => e.MsgID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_collection>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_collection>()
                .Property(e => e.ReceiverID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_group>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_group>()
                .Property(e => e.OwnerID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_group>()
                .Property(e => e.GroupName)
                .IsUnicode(false);

            modelBuilder.Entity<msg_group>()
                .Property(e => e.CrewLimiteTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_group>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<msg_send_record>()
                .Property(e => e.MsgSendRecordID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_send_record>()
                .Property(e => e.MsgID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_send_record>()
                .Property(e => e.ReceiverID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_send_record>()
                .Property(e => e.OutStateID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_send_record>()
                .Property(e => e.InStateID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_type>()
                .Property(e => e.MsgTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_type>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<msg_type>()
                .Property(e => e.TypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<msg_type>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<msg_type>()
                .HasMany(e => e.msg)
                .WithOptional(e => e.msg_type)
                .WillCascadeOnDelete();

            modelBuilder.Entity<msg_user>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<msg_user>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<msg_user>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<msg_user>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<msg_user>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<msg_user>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<msg_user>()
                .HasMany(e => e.contact)
                .WithRequired(e => e.msg_user)
                .HasForeignKey(e => e.MembersID);

            modelBuilder.Entity<msg_user>()
                .HasMany(e => e.group_member)
                .WithRequired(e => e.msg_user)
                .HasForeignKey(e => e.MembersID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<msg_user>()
                .HasMany(e => e.msg)
                .WithOptional(e => e.msg_user)
                .HasForeignKey(e => e.SenderID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<msg_user>()
                .HasMany(e => e.msg_collection)
                .WithRequired(e => e.msg_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<msg_user>()
                .HasMany(e => e.msg_group)
                .WithRequired(e => e.msg_user)
                .HasForeignKey(e => e.OwnerID);

            modelBuilder.Entity<msg_user>()
                .HasMany(e => e.msg_send_record)
                .WithOptional(e => e.msg_user)
                .HasForeignKey(e => e.ReceiverID);

            modelBuilder.Entity<out_state>()
                .Property(e => e.OutStateID)
                .IsUnicode(false);

            modelBuilder.Entity<out_state>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<out_state>()
                .HasMany(e => e.msg_send_record)
                .WithOptional(e => e.out_state)
                .WillCascadeOnDelete();

            modelBuilder.Entity<sms_send_record>()
                .Property(e => e.RequestId)
                .IsUnicode(false);

            modelBuilder.Entity<sms_send_record>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<sms_send_record>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<sms_send_record>()
                .Property(e => e.SignName)
                .IsUnicode(false);

            modelBuilder.Entity<sms_send_record>()
                .Property(e => e.TemplateCode)
                .IsUnicode(false);

            modelBuilder.Entity<sms_send_record>()
                .Property(e => e.ParamString)
                .IsUnicode(false);

            modelBuilder.Entity<sms_send_record>()
                .Property(e => e.Sender)
                .IsUnicode(false);

            modelBuilder.Entity<sms_send_record>()
                .Property(e => e.ErrorMessage)
                .IsUnicode(false);

            modelBuilder.Entity<timer_msg>()
                .Property(e => e.TimerMsgID)
                .IsUnicode(false);

            modelBuilder.Entity<timer_msg>()
                .Property(e => e.MsgID)
                .IsUnicode(false);
        }
    }
}
