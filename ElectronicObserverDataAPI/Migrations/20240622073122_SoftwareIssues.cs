using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicObserverDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class SoftwareIssues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoftwareIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SoftwareVersion = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    StackTrace = table.Column<string>(type: "TEXT", nullable: false),
                    IssueState = table.Column<int>(type: "INTEGER", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SoftwareIssueModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareIssues_SoftwareIssues_SoftwareIssueModelId",
                        column: x => x.SoftwareIssueModelId,
                        principalTable: "SoftwareIssues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareIssues_SoftwareIssueModelId",
                table: "SoftwareIssues",
                column: "SoftwareIssueModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoftwareIssues");
        }
    }
}
