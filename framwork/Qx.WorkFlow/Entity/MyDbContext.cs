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


        public virtual DbSet<ConvertCondition> ConvertConditions { get; set; }
        public virtual DbSet<NodeRelation> NodeRelations { get; set; }
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<WorkFlowInstanceLog> WorkFlowInstanceLogs { get; set; }
        public virtual DbSet<WorkFlowInstance> WorkFlowInstances { get; set; }
        public virtual DbSet<WorkFlow> WorkFlows { get; set; }

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
                .HasMany(e => e.NodeRelations)
                .WithRequired(e => e.Node)
                .HasForeignKey(e => e.NodeID);

            modelBuilder.Entity<Node>()
                .HasMany(e => e.NodeRelations1)
                .WithOptional(e => e.Node1)
                .HasForeignKey(e => e.ChildID);

            modelBuilder.Entity<Node>()
                .HasMany(e => e.WorkFlowInstanceLogs)
                .WithOptional(e => e.Node)
                .HasForeignKey(e => e.FromNodeID);

            modelBuilder.Entity<Node>()
                .HasMany(e => e.WorkFlowInstances)
                .WithOptional(e => e.Node)
                .HasForeignKey(e => e.CurrentNodeID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Node>()
                .HasMany(e => e.WorkFlows)
                .WithOptional(e => e.Node)
                .HasForeignKey(e => e.StartNodeID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<WorkFlowInstanceLog>()
                .Property(e => e.WorkFlowInstanceLogId)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlowInstanceLog>()
                .Property(e => e.WorkFlowInstanceID)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlowInstanceLog>()
                .Property(e => e.FromNodeID)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlowInstanceLog>()
                .Property(e => e.ToNodeID)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlowInstanceLog>()
                .Property(e => e.Operator)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlowInstanceLog>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<WorkFlowInstanceLog>()
                .Property(e => e.Note)
                .IsUnicode(false);

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
                .HasMany(e => e.WorkFlowInstances)
                .WithRequired(e => e.WorkFlow)
                .WillCascadeOnDelete(false);
        }
    }
}
