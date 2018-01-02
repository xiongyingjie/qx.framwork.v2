
using Microsoft.EntityFrameworkCore;
using Qx.Account.Configs;
using Qx.Tools;

namespace Qx.Account.Entity
{
    public partial class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(Setting.ConnectionString);
        }
        public virtual DbSet<account> account { get; set; }
        public virtual DbSet<account_record> account_record { get; set; }
        public virtual DbSet<account_type> account_type { get; set; }
        public virtual DbSet<order_type> order_type { get; set; }
        public virtual DbSet<pay_order> pay_order { get; set; }
        public virtual DbSet<pay_state> pay_state { get; set; }
        public virtual DbSet<payment_type> payment_type { get; set; }
        public virtual DbSet<withdraw_apply> withdraw_apply { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.AccountID)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.AccType)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.pay_order);

            modelBuilder.Entity<account_record>()
                .Property(e => e.AccountRecordID)
                .IsUnicode(false);

            modelBuilder.Entity<account_record>()
                .Property(e => e.AccountID)
                .IsUnicode(false);

            modelBuilder.Entity<account_record>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<account_record>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<account_record>()
                .Property(e => e.PO_ID)
                .IsUnicode(false);

            modelBuilder.Entity<account_type>()
                .Property(e => e.AccTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<account_type>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<account_type>()
                .HasMany(e => e.account);

            modelBuilder.Entity<order_type>()
                .Property(e => e.OrderTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<order_type>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<order_type>()
                .HasMany(e => e.pay_order);

            modelBuilder.Entity<pay_order>()
                .Property(e => e.PO_ID)
                .IsUnicode(false);

            modelBuilder.Entity<pay_order>()
                .Property(e => e.PayerAccID)
                .IsUnicode(false);

            modelBuilder.Entity<pay_order>()
                .Property(e => e.ReceiverAccID)
                .IsUnicode(false);

            modelBuilder.Entity<pay_order>()
                .Property(e => e.PayOrderTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<pay_order>()
                .Property(e => e.PaymentTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<pay_order>()
                .Property(e => e.PayStateID)
                .IsUnicode(false);

            modelBuilder.Entity<pay_order>()
                .Property(e => e.AliPayID)
                .IsUnicode(false);

            modelBuilder.Entity<pay_state>()
                .Property(e => e.PayStateID)
                .IsUnicode(false);

            modelBuilder.Entity<pay_state>()
                .Property(e => e.PayStateName)
                .IsUnicode(false);

            modelBuilder.Entity<payment_type>()
                .Property(e => e.PaymentTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<payment_type>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<withdraw_apply>()
                .Property(e => e.WithdrawApplyID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
