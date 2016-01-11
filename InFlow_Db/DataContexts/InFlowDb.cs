using strICT.InFlow.Db.Contracts.InFlow;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.DataContexts
{
    public class InFlowDb : DbContext
    {
        public InFlowDb()
            : base("DefaultConnection")
        {
        }

        public InFlowDb(string connString)
            : base(connString)
        {}

        public DbSet<WS_Folder> WS_Folders { get; set; }
        public DbSet<WS_Project> WS_Projects { get; set; }
        public DbSet<WS_Subject> WS_Subjects { get; set; }
        public DbSet<WS_ModelVersion> WS_ModelVersions { get; set; }

        public DbSet<U_FunctionGroup> U_FunctionGroups { get; set; }
        public DbSet<U_Role> U_Roles { get; set; }
        public DbSet<U_User_FunctionGroup> U_User_FunctionGroups { get; set; }

        public DbSet<P_Process> P_Processes { get; set; }

        public DbSet<P_ProcessInstance> P_ProcessInstance { get; set; }
        public DbSet<P_ProcessSubject> P_ProcessSubjects { get; set; }
        public DbSet<P_WorkflowInstance> P_WorkflowInstances { get; set; }

        public DbSet<T_Task> T_Tasks { get; set; }

        public DbSet<M_Message> M_Messages { get; set; }

        public DbSet<C_Property> C_Properties { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<U_Role>().
                HasMany(r => r.FunctionGroups).
                WithMany(f => f.Roles).
                Map(
                m =>
                {
                    m.MapLeftKey("Role_Id");
                    m.MapRightKey("FunctionGroup_Id");
                    m.ToTable("U_FunctionGroup_Role");
                }
                );

            modelBuilder.Entity<T_Task>()
                .HasMany(a => a.TaskProperties)
                .WithRequired(b => b.T_Task)
                .WillCascadeOnDelete(true);
        }
    }
}
