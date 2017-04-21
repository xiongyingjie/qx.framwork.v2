using System.Data.Entity;
using Qx.Bysj.Jzxt.Configs;

namespace Qx.Bysj.Jzxt.Entity
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
              : base((string) Setting.ConnectionString)
        {
        }

        public virtual DbSet<allocation_for_award> allocation_for_award { get; set; }
        public virtual DbSet<apply_information_type> apply_information_type { get; set; }
        public virtual DbSet<audit_by_institute> audit_by_institute { get; set; }
        public virtual DbSet<audit_object> audit_object { get; set; }
        public virtual DbSet<audit_object_apply> audit_object_apply { get; set; }
        public virtual DbSet<audit_object_apply_extend> audit_object_apply_extend { get; set; }
        public virtual DbSet<audit_object_award> audit_object_award { get; set; }
        public virtual DbSet<audit_object_information_for_award> audit_object_information_for_award { get; set; }
        public virtual DbSet<audit_object_information_type> audit_object_information_type { get; set; }
        public virtual DbSet<award_list_design> award_list_design { get; set; }
        public virtual DbSet<award_type> award_type { get; set; }
        public virtual DbSet<data_list_design> data_list_design { get; set; }
        public virtual DbSet<data_list_option> data_list_option { get; set; }
        public virtual DbSet<data_list_type> data_list_type { get; set; }
        public virtual DbSet<data_list_Value> data_list_Value { get; set; }
        public virtual DbSet<data_type> data_type { get; set; }
        public virtual DbSet<data_use_history> data_use_history { get; set; }
        public virtual DbSet<Jurisdiction_For_Auditdata> Jurisdiction_For_Auditdata { get; set; }
        public virtual DbSet<Jurisdiction_For_Award> Jurisdiction_For_Award { get; set; }
        public virtual DbSet<operation> operation { get; set; }
        public virtual DbSet<review_rule> review_rule { get; set; }
        public virtual DbSet<review_type> review_type { get; set; }
        public virtual DbSet<reviewer> reviewer { get; set; }
        public virtual DbSet<unit> unit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<allocation_for_award>()
                .Property(e => e.AwardAllocationID)
                .IsUnicode(false);

            modelBuilder.Entity<allocation_for_award>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<apply_information_type>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<apply_information_type>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<audit_by_institute>()
                .Property(e => e.PassID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_by_institute>()
                .Property(e => e.AuditObjectID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_by_institute>()
                .Property(e => e.ReviewerID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object>()
                .Property(e => e.AuditObjectID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object>()
                .Property(e => e.StudentNumber)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object>()
                .Property(e => e.PoliticalLandscape)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object>()
                .Property(e => e.Score)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object>()
                .Property(e => e.CommunityScore)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object>()
                .HasMany(e => e.audit_object_award)
                .WithRequired(e => e.audit_object)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<audit_object_apply>()
                .Property(e => e.ApplyID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_apply>()
                .Property(e => e.AuditObjectID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_apply_extend>()
                .Property(e => e.ExtendID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_apply_extend>()
                .Property(e => e.ApplyID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_apply_extend>()
                .Property(e => e.Information)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_apply_extend>()
                .Property(e => e.InformationValue)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_award>()
                .Property(e => e.GetAwardID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_award>()
                .Property(e => e.AuditObjectID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_award>()
                .Property(e => e.bonus)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_award>()
                .Property(e => e.ReviewerID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_information_for_award>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_information_for_award>()
                .Property(e => e.Desription)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_information_type>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<audit_object_information_type>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<award_list_design>()
                .Property(e => e.ListID)
                .IsUnicode(false);

            modelBuilder.Entity<award_list_design>()
                .Property(e => e.ListName)
                .IsUnicode(false);

            modelBuilder.Entity<award_list_design>()
                .Property(e => e.DefaultValue)
                .IsUnicode(false);

            modelBuilder.Entity<award_list_design>()
                .HasMany(e => e.review_rule)
                .WithRequired(e => e.award_list_design)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<award_type>()
                .Property(e => e.AwardName)
                .IsUnicode(false);

            modelBuilder.Entity<award_type>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<award_type>()
                .HasMany(e => e.allocation_for_award)
                .WithRequired(e => e.award_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<award_type>()
                .HasMany(e => e.audit_object_award)
                .WithRequired(e => e.award_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<data_list_design>()
                .Property(e => e.ListID)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_design>()
                .Property(e => e.ListName)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_design>()
                .Property(e => e.DefaultValue)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_option>()
                .Property(e => e.LlistOptionID)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_option>()
                .Property(e => e.ListID)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_option>()
                .Property(e => e.OptionValue)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_option>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_type>()
                .Property(e => e.ListName)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_type>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_Value>()
                .Property(e => e.ValueID)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_Value>()
                .Property(e => e.ListID)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_Value>()
                .Property(e => e.ListValue)
                .IsUnicode(false);

            modelBuilder.Entity<data_list_Value>()
                .Property(e => e.AuditObjectID)
                .IsUnicode(false);

            modelBuilder.Entity<data_type>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<data_type>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<data_use_history>()
                .Property(e => e.DataUseHistoryID)
                .IsUnicode(false);

            modelBuilder.Entity<data_use_history>()
                .Property(e => e.AuditDataID)
                .IsUnicode(false);

            modelBuilder.Entity<data_use_history>()
                .Property(e => e.Time)
                .IsUnicode(false);

            modelBuilder.Entity<Jurisdiction_For_Auditdata>()
                .Property(e => e.AuditDataJurisdicitionID)
                .IsUnicode(false);

            modelBuilder.Entity<Jurisdiction_For_Auditdata>()
                .Property(e => e.ReviewerID)
                .IsUnicode(false);

            modelBuilder.Entity<Jurisdiction_For_Auditdata>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Jurisdiction_For_Award>()
                .Property(e => e.JrisditionForAwardID)
                .IsUnicode(false);

            modelBuilder.Entity<Jurisdiction_For_Award>()
                .Property(e => e.ReviewerID)
                .IsUnicode(false);

            modelBuilder.Entity<Jurisdiction_For_Award>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<operation>()
                .Property(e => e.OperateID)
                .IsUnicode(false);

            modelBuilder.Entity<operation>()
                .Property(e => e.OperateContent)
                .IsUnicode(false);

            modelBuilder.Entity<operation>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<operation>()
                .HasMany(e => e.review_rule)
                .WithRequired(e => e.operation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<review_rule>()
                .Property(e => e.RuleID)
                .IsUnicode(false);

            modelBuilder.Entity<review_rule>()
                .Property(e => e.ListID)
                .IsUnicode(false);

            modelBuilder.Entity<review_rule>()
                .Property(e => e.OperateID)
                .IsUnicode(false);

            modelBuilder.Entity<review_rule>()
                .Property(e => e.ConstraintValue)
                .IsUnicode(false);

            modelBuilder.Entity<review_type>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<review_type>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<reviewer>()
                .Property(e => e.ReviewerID)
                .IsUnicode(false);

            modelBuilder.Entity<reviewer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<reviewer>()
                .HasMany(e => e.Jurisdiction_For_Award)
                .WithRequired(e => e.reviewer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<unit>()
                .Property(e => e.UnitName)
                .IsUnicode(false);

            modelBuilder.Entity<unit>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<unit>()
                .HasMany(e => e.allocation_for_award)
                .WithRequired(e => e.unit)
                .WillCascadeOnDelete(false);
        }
    }
}
