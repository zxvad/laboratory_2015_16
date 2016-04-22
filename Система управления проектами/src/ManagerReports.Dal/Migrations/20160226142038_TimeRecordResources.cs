using System;
using Microsoft.Data.Entity.Migrations;

namespace ManagerReports.Dal.Migrations
{
    public partial class TimeRecordResources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_EmployeeSoldResource_Employee_EmployeeId", table: "EmployeeSoldResources");
            migrationBuilder.DropForeignKey(name: "FK_EmployeeSoldResource_SoldResource_SoldResourceId", table: "EmployeeSoldResources");
            migrationBuilder.DropColumn(name: "ResourceName", table: "TimeRecords");
            migrationBuilder.CreateTable(
                name: "ResourceTimeRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false),
                    TimeRecordId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTimeRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceTimeRecord_SoldResource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "SoldResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceTimeRecord_TimeRecord_TimeRecordId",
                        column: x => x.TimeRecordId,
                        principalTable: "TimeRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSoldResource_Employee_EmployeeId",
                table: "EmployeeSoldResources",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSoldResource_SoldResource_SoldResourceId",
                table: "EmployeeSoldResources",
                column: "SoldResourceId",
                principalTable: "SoldResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_EmployeeSoldResource_Employee_EmployeeId", table: "EmployeeSoldResources");
            migrationBuilder.DropForeignKey(name: "FK_EmployeeSoldResource_SoldResource_SoldResourceId", table: "EmployeeSoldResources");
            migrationBuilder.DropTable("ResourceTimeRecords");
            migrationBuilder.AddColumn<string>(
                name: "ResourceName",
                table: "TimeRecords",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSoldResource_Employee_EmployeeId",
                table: "EmployeeSoldResources",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSoldResource_SoldResource_SoldResourceId",
                table: "EmployeeSoldResources",
                column: "SoldResourceId",
                principalTable: "SoldResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
