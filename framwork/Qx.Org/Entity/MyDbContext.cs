using System.Data.Entity;
using Qx.Org.Configs;

namespace Qx.Org.Entity
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
             : base((string) Setting.ConnectionString)
        {
        }
        public virtual DbSet<L_Org_Pos> L_Org_Pos { get; set; }
        public virtual DbSet<OrgAccount> OrgAccounts { get; set; }
        public virtual DbSet<OrgAccType> OrgAccTypes { get; set; }
        public virtual DbSet<OrgAsset> OrgAssets { get; set; }
        public virtual DbSet<OrgAssetType> OrgAssetTypes { get; set; }
        public virtual DbSet<Orgnization> Orgnizations { get; set; }
        public virtual DbSet<OrgType> OrgTypes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PositionType> PositionTypes { get; set; }
        public virtual DbSet<R_Accounts> R_Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<L_Org_Pos>()
                .Property(e => e.L_O_P_ID)
                .IsUnicode(false);

            modelBuilder.Entity<L_Org_Pos>()
                .Property(e => e.O_ID)
                .IsUnicode(false);

            modelBuilder.Entity<L_Org_Pos>()
                .Property(e => e.PositionID)
                .IsUnicode(false);

            modelBuilder.Entity<OrgAccount>()
                .Property(e => e.OA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OrgAccount>()
                .Property(e => e.O_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OrgAccount>()
                .Property(e => e.AccountID)
                .IsUnicode(false);

            modelBuilder.Entity<OrgAccount>()
                .Property(e => e.AccTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<OrgAccType>()
                .Property(e => e.AccTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<OrgAccType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<OrgAsset>()
                .Property(e => e.OrgAssetID)
                .IsUnicode(false);

            modelBuilder.Entity<OrgAsset>()
                .Property(e => e.O_ID)
                .IsUnicode(false);

            modelBuilder.Entity<OrgAsset>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<OrgAssetType>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<OrgAssetType>()
                .HasMany(e => e.OrgAssets)
                .WithOptional(e => e.OrgAssetType)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Orgnization>()
                .Property(e => e.O_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Orgnization>()
                .Property(e => e.FatherID)
                .IsUnicode(false);

            modelBuilder.Entity<Orgnization>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Orgnization>()
                .Property(e => e.Descripe)
                .IsUnicode(false);

            modelBuilder.Entity<Orgnization>()
                .Property(e => e.TypeID)
                .IsUnicode(false);

            modelBuilder.Entity<Orgnization>()
                .Property(e => e.Province)
                .IsUnicode(false);

            modelBuilder.Entity<Orgnization>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Orgnization>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<Orgnization>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Orgnization>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Orgnization>()
                .HasMany(e => e.L_Org_Pos)
                .WithOptional(e => e.Orgnization)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Orgnization>()
                .HasMany(e => e.OrgAssets)
                .WithOptional(e => e.Orgnization)
                .WillCascadeOnDelete();

            modelBuilder.Entity<OrgType>()
                .Property(e => e.TypeID)
                .IsUnicode(false);

            modelBuilder.Entity<OrgType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<OrgType>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.PositionID)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.PositionTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Descripe)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.L_Org_Pos)
                .WithOptional(e => e.Position)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PositionType>()
                .Property(e => e.PositionTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<PositionType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PositionType>()
                .Property(e => e.FatherID)
                .IsUnicode(false);

            modelBuilder.Entity<PositionType>()
                .HasMany(e => e.Positions)
                .WithOptional(e => e.PositionType)
                .WillCascadeOnDelete();

            modelBuilder.Entity<R_Accounts>()
                .Property(e => e.AccountID)
                .IsUnicode(false);
        }
    }
}
