using System.Data.Entity;
using Qx.Order.Configs;

namespace Qx.Order.Entity
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
              : base((string) Setting.ConnectionString)
        {
        }
        public virtual DbSet<order> order { get; set; }
        public virtual DbSet<order_item> order_item { get; set; }
        public virtual DbSet<order_pay_item> order_pay_item { get; set; }
        public virtual DbSet<order_state> order_state { get; set; }
        public virtual DbSet<order_type> order_type { get; set; }
        public virtual DbSet<r_orgnization> r_orgnization { get; set; }
        public virtual DbSet<r_pay_order> r_pay_order { get; set; }
        public virtual DbSet<r_product> r_product { get; set; }
        public virtual DbSet<r_user> r_user { get; set; }
        public virtual DbSet<sell_consultant> sell_consultant { get; set; }
        public virtual DbSet<shopping_cart> shopping_cart { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<order>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.OrderTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.SellerID)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.BuyerID)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.OrderStateID)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.ShopID)
                .IsUnicode(false);

            modelBuilder.Entity<order_item>()
                .Property(e => e.SellOrderItemID)
                .IsUnicode(false);

            modelBuilder.Entity<order_item>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<order_item>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<order_item>()
                .Property(e => e.BenefitDesc)
                .IsUnicode(false);

            modelBuilder.Entity<order_item>()
                .HasOptional(e => e.sell_consultant)
                .WithRequired(e => e.order_item)
                .WillCascadeOnDelete();

            modelBuilder.Entity<order_pay_item>()
                .Property(e => e.OrderPayItemsID)
                .IsUnicode(false);

            modelBuilder.Entity<order_pay_item>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<order_pay_item>()
                .Property(e => e.PO_ID)
                .IsUnicode(false);

            modelBuilder.Entity<order_state>()
                .Property(e => e.OrderStateID)
                .IsUnicode(false);

            modelBuilder.Entity<order_state>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<order_type>()
                .Property(e => e.OrderTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<order_type>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<order_type>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<order_type>()
                .HasMany(e => e.order)
                .WithOptional(e => e.order_type)
                .WillCascadeOnDelete();

            modelBuilder.Entity<r_orgnization>()
                .Property(e => e.OrgID)
                .IsUnicode(false);

            modelBuilder.Entity<r_orgnization>()
                .HasMany(e => e.order)
                .WithOptional(e => e.r_orgnization)
                .HasForeignKey(e => e.ShopID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<r_pay_order>()
                .Property(e => e.PO_ID)
                .IsUnicode(false);

            modelBuilder.Entity<r_product>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<r_user>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<r_user>()
                .HasMany(e => e.order)
                .WithOptional(e => e.r_user)
                .HasForeignKey(e => e.SellerID);

            modelBuilder.Entity<r_user>()
                .HasMany(e => e.order1)
                .WithRequired(e => e.r_user1)
                .HasForeignKey(e => e.BuyerID);

            modelBuilder.Entity<r_user>()
                .HasMany(e => e.shopping_cart)
                .WithRequired(e => e.r_user)
                .HasForeignKey(e => e.SellerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<r_user>()
                .HasMany(e => e.shopping_cart1)
                .WithRequired(e => e.r_user1)
                .HasForeignKey(e => e.BuyerID);

            modelBuilder.Entity<sell_consultant>()
                .Property(e => e.SellConsultantID)
                .IsUnicode(false);

            modelBuilder.Entity<sell_consultant>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<shopping_cart>()
                .Property(e => e.SC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<shopping_cart>()
                .Property(e => e.BuyerID)
                .IsUnicode(false);

            modelBuilder.Entity<shopping_cart>()
                .Property(e => e.SellerID)
                .IsUnicode(false);

            modelBuilder.Entity<shopping_cart>()
                .Property(e => e.ProductID)
                .IsUnicode(false);
        }
    }
}
