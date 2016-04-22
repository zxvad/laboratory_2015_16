using ManagerReports.Dal.Entities;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Extensions.Configuration;

namespace ManagerReports.Dal
{
    public class ManagerReportsContext : DbContext
    {
        private readonly IConfigurationRoot _configurationRoot;

        public ManagerReportsContext()
        {
            _configurationRoot = new Startup().Configuration;
        }

        public ManagerReportsContext(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<ProjectVersionEntity> ProjectVersions { get; set; } 
        public DbSet<PaymentRecordEntity> Payments { get; set; }
        public DbSet<TimeRecordEntity> TimeRecords { get; set; }
        public DbSet<SoldResourceEntity> SoldResources { get; set; }
        public DbSet<IssueEntity> Issues { get; set; }
        public DbSet<IssueStatusEntity> IssueStatuses { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configurationRoot["Data:ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProjectVersionCreating(modelBuilder);
            SoldResourceCreating(modelBuilder);
            PaymentCreating(modelBuilder);
            IssueCreating(modelBuilder);
            EmployeeSoldResourcesCreating(modelBuilder);
            TimeRecordsCreating(modelBuilder);
        }

        private static void ProjectVersionCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectVersionEntity>()
                .HasAlternateKey(i => i.ExternalId);

            modelBuilder.Entity<ProjectVersionEntity>()
                .HasOne(pv => pv.Project)
                .WithMany(p => p.Versions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(pv => pv.ProjectId);

            modelBuilder.Entity<ProjectVersionEntity>()
                .HasMany(pv => pv.Issues)
                .WithOne(i => i.ProjectVersion)
                .HasPrincipalKey(pv => pv.ExternalId)
                .IsRequired(false);

            modelBuilder.Entity<ProjectVersionEntity>()
                .HasMany(pv => pv.Payments)
                .WithOne(p => p.ProjectVersion)
                .HasPrincipalKey(pv => pv.ExternalId)
                .IsRequired(false);

            modelBuilder.Entity<ProjectVersionEntity>()
                .HasMany(pv => pv.SoldResources)
                .WithOne(r => r.ProjectVersion)
                .HasPrincipalKey(pv => pv.ExternalId)
                .IsRequired(false);
        }

        private static void SoldResourceCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoldResourceEntity>()
                .HasOne(sr => sr.Project)
                .WithMany(p => p.SoldResources)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(sr => sr.ProjectId);
        }

        private static void PaymentCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentRecordEntity>()
                .HasOne(p => p.Project)
                .WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.ProjectId);
        }

        private static void IssueCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IssueEntity>()
                .HasOne(i => i.Project)
                .WithMany(p => p.Issues)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(i => i.ProjectId);

            modelBuilder.Entity<IssueEntity>()
                .HasOne(i => i.IssueStatus)
                .WithMany(i => i.Issues)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(i => i.IssueStatusId);
        }

        private static void EmployeeSoldResourcesCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeSoldResourceEntity>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.SoldResources)
                .HasForeignKey(es => es.EmployeeId);

            modelBuilder.Entity<EmployeeSoldResourceEntity>()
                .HasOne(es => es.SoldResource)
                .WithMany(s => s.Employees)
                .HasForeignKey(es => es.SoldResourceId);

            modelBuilder.Entity<ResourceTimeRecordEntity>()
                .HasOne(rt => rt.Resource)
                .WithMany(r => r.TimeRecords)
                .HasForeignKey(rt => rt.ResourceId);

            modelBuilder.Entity<ResourceTimeRecordEntity>()
                .HasOne(rt => rt.TimeRecord)
                .WithMany(tr => tr.Resources)
                .HasForeignKey(rt => rt.TimeRecordId);
        }

        private static void TimeRecordsCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeRecordEntity>()
                .HasOne(tr => tr.Issue)
                .WithMany(i => i.TimeRecords)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(i => i.IssueId);

            modelBuilder.Entity<TimeRecordEntity>()
                .HasOne(tr => tr.Employee)
                .WithMany(e => e.TimeRecords)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(tr => tr.EmployeeId);
        }
    }
}