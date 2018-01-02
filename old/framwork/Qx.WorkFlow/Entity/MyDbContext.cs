using System.Data.Entity;
using Qx.WorkFlow.Configs;

namespace Qx.WorkFlow.Entity
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
              : base((string) Setting.ConnectionString)
        {
        }

        public virtual DbSet<ConvertCondition> ConvertCondition { get; set; }
        public virtual DbSet<InstanceChangeLog> InstanceChangeLog { get; set; }
        public virtual DbSet<InstanceChangeLogType> InstanceChangeLogType { get; set; }
        public virtual DbSet<InstanceHistory> InstanceHistory { get; set; }
        public virtual DbSet<InstanceHistoryType> InstanceHistoryType { get; set; }
        public virtual DbSet<Node> Node { get; set; }
        public virtual DbSet<NodeRelation> NodeRelation { get; set; }
        public virtual DbSet<WorkFlow> WorkFlow { get; set; }
        public virtual DbSet<WorkFlowInstance> WorkFlowInstance { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConvertCondition>()
                .Property(e => e.ConvertConditionID)
                .IsUnicode(false);

            modelBuilder.Entity<ConvertCondition>()
                .Property(e => e.NodeRelationID)
                .IsUnicode(false);

            modelBuilder.Entity<ConvertCondition>()
                .Property(e => e.ConditionNote)
                .IsUnicode(false);

            modelBuilder.Entity<ConvertCondition>()
                .Property(e => e.Property)
                .IsUnicode(false);

            modelBuilder.Entity<ConvertCondition>()
                .Property(e => e.Operator)
                .IsUnicode(false);

            modelBuilder.Entity<ConvertCondition>()
                .Property(e => e.PropertyValue)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceChangeLog>()
                .Property(e => e.InstanceChangeLogID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceChangeLog>()
                .Property(e => e.WorkFlowInstanceID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceChangeLog>()
                .Property(e => e.FromNodeID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceChangeLog>()
                .Property(e => e.ToNodeID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceChangeLog>()
                .Property(e => e.Operator)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceChangeLog>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceChangeLog>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceChangeLog>()
                .Property(e => e.InstanceChangeLogTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceChangeLogType>()
                .Property(e => e.InstanceChangeLogTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceChangeLogType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceChangeLogType>()
                .HasMany(e => e.InstanceChangeLog)
                .WithOptional(e => e.InstanceChangeLogType)
                .WillCascadeOnDelete();

            modelBuilder.Entity<InstanceHistory>()
                .Property(e => e.WorkFlowInstanceID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceHistory>()
                .Property(e => e.WorkFlowID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceHistory>()
                .Property(e => e.CurrentNodeID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceHistory>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceHistory>()
                .Property(e => e.InstancePeople)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceHistory>()
                .Property(e => e.InstanceHistoryTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceHistory>()
                .Property(e => e.UnitID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceHistoryType>()
                .Property(e => e.InstanceHistoryTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<InstanceHistoryType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.NodeID)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.WorkFlowID)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.MenuID)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.Domain)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Node>()
                .HasMany(e => e.InstanceChangeLog)
                .WithOptional(e => e.Node)
                .HasForeignKey(e => e.FromNodeID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Node>()
                .HasMany(e => e.WorkFlowInstance)
                .WithOptional(e => e.Node)
                .HasForeignKey(e => e.CurrentNodeID);

            modelBuilder.Entity<Node>()
                .HasMany(e => e.WorkFlow)
                .WithOptional(e => e.Node)
                .HasForeignKey(e => e.StartNodeID);

            modelBuilder.Entity<NodeRelation>()
                .Property(e => e.NodeRelationID)
                .IsUnicode(false);

            modelBuilder.Entity<NodeRelation>()
                .Property(e => e.NodeID)
                .IsUnicode(false);

            modelBuilder.Entity<NodeRelation>()
                .Property(e => e.ChildID)
                .IsUnicode(false);

            modelBuilder.Entity<NodeRelation>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlow>()
                .Property(e => e.WorkFlowID)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlow>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlow>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlow>()
                .Property(e => e.StartNodeID)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlow>()
                .HasMany(e => e.Node1)
                .WithOptional(e => e.WorkFlow1)
                .HasForeignKey(e => e.WorkFlowID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<WorkFlow>()
                .HasMany(e => e.WorkFlowInstance)
                .WithRequired(e => e.WorkFlow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkFlowInstance>()
                .Property(e => e.WorkFlowInstanceID)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlowInstance>()
                .Property(e => e.WorkFlowID)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlowInstance>()
                .Property(e => e.CurrentNodeID)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlowInstance>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlowInstance>()
                .Property(e => e.InstancePeople)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlowInstance>()
                .Property(e => e.UnitID)
                .IsUnicode(false);
        }
    }
}
