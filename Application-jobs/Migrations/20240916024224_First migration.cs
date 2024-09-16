using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application_jobs.Migrations
{
    /// <inheritdoc />
    public partial class Firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationJob",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    JobDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SkillRequest = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Interviews = table.Column<int>(type: "int", nullable: true),
                    TecnicTest = table.Column<bool>(type: "bit", nullable: false),
                    Recruter = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    LastUpdateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationJob_ApplicationStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ApplicationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationJob_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationStatus",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "C01", "APPLIED" },
                    { 2, "C02", "IN PROCESS" },
                    { 3, "C03", "INTERVIEW" },
                    { 4, "C04", "CLOSED" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationJob_CompanyId",
                table: "ApplicationJob",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationJob_StatusId",
                table: "ApplicationJob",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationJob");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
