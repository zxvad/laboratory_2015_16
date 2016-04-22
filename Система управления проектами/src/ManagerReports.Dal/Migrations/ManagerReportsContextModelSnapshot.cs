using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ManagerReports.Dal;

namespace ManagerReports.Dal.Migrations
{
    [DbContext(typeof(ManagerReportsContext))]
    partial class ManagerReportsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManagerReports.Dal.Entities.EmployeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int?>("ExternalId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<decimal>("SelfRate");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Employees");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.EmployeeSoldResourceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EmployeeId");

                    b.Property<Guid>("SoldResourceId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "EmployeeSoldResources");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.IssueEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignedTo");

                    b.Property<string>("Author");

                    b.Property<string>("Description");

                    b.Property<int?>("ExternalId");

                    b.Property<Guid>("IssueStatusId");

                    b.Property<string>("Priority");

                    b.Property<Guid>("ProjectId");

                    b.Property<int?>("ProjectVersionId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Issues");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.IssueStatusEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ExternalId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "IssueStatuses");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.PaymentRecordEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("ProjectId");

                    b.Property<int?>("ProjectVersionId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Payments");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.ProjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BegintDate");

                    b.Property<int>("Currency");

                    b.Property<string>("Description");

                    b.Property<int?>("ExternalId");

                    b.Property<bool>("HasProblems");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Projects");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.ProjectVersionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<int?>("ExternalId");

                    b.Property<string>("Name");

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "ProjectVersions");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.ResourceTimeRecordEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ResourceId");

                    b.Property<Guid>("TimeRecordId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "ResourceTimeRecords");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.SoldResourceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Hours");

                    b.Property<string>("Name");

                    b.Property<Guid>("ProjectId");

                    b.Property<int?>("ProjectVersionId");

                    b.Property<decimal>("Rate");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "SoldResources");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.TimeRecordEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Activity");

                    b.Property<string>("Comments");

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("EmployeeId");

                    b.Property<int?>("ExternalId");

                    b.Property<decimal>("Hours");

                    b.Property<Guid>("IssueId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "TimeRecords");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.EmployeeSoldResourceEntity", b =>
                {
                    b.HasOne("ManagerReports.Dal.Entities.EmployeeEntity")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("ManagerReports.Dal.Entities.SoldResourceEntity")
                        .WithMany()
                        .HasForeignKey("SoldResourceId");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.IssueEntity", b =>
                {
                    b.HasOne("ManagerReports.Dal.Entities.IssueStatusEntity")
                        .WithMany()
                        .HasForeignKey("IssueStatusId");

                    b.HasOne("ManagerReports.Dal.Entities.ProjectEntity")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("ManagerReports.Dal.Entities.ProjectVersionEntity")
                        .WithMany()
                        .HasForeignKey("ProjectVersionId")
                        .HasPrincipalKey("ExternalId");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.PaymentRecordEntity", b =>
                {
                    b.HasOne("ManagerReports.Dal.Entities.ProjectEntity")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("ManagerReports.Dal.Entities.ProjectVersionEntity")
                        .WithMany()
                        .HasForeignKey("ProjectVersionId")
                        .HasPrincipalKey("ExternalId");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.ProjectVersionEntity", b =>
                {
                    b.HasOne("ManagerReports.Dal.Entities.ProjectEntity")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.ResourceTimeRecordEntity", b =>
                {
                    b.HasOne("ManagerReports.Dal.Entities.SoldResourceEntity")
                        .WithMany()
                        .HasForeignKey("ResourceId");

                    b.HasOne("ManagerReports.Dal.Entities.TimeRecordEntity")
                        .WithMany()
                        .HasForeignKey("TimeRecordId");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.SoldResourceEntity", b =>
                {
                    b.HasOne("ManagerReports.Dal.Entities.ProjectEntity")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("ManagerReports.Dal.Entities.ProjectVersionEntity")
                        .WithMany()
                        .HasForeignKey("ProjectVersionId")
                        .HasPrincipalKey("ExternalId");
                });

            modelBuilder.Entity("ManagerReports.Dal.Entities.TimeRecordEntity", b =>
                {
                    b.HasOne("ManagerReports.Dal.Entities.EmployeeEntity")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("ManagerReports.Dal.Entities.IssueEntity")
                        .WithMany()
                        .HasForeignKey("IssueId");
                });
        }
    }
}
