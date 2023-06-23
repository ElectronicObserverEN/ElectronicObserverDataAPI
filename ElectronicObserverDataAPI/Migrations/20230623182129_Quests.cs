using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicObserverDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class Quests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentUpgradeIssuesController",
                table: "EquipmentUpgradeIssuesController");

            migrationBuilder.RenameTable(
                name: "EquipmentUpgradeIssuesController",
                newName: "EquipmentUpgradeIssues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentUpgradeIssues",
                table: "EquipmentUpgradeIssues",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuestTranslationMissing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SoftwareVersion = table.Column<string>(type: "TEXT", nullable: false),
                    DataVersion = table.Column<int>(type: "INTEGER", nullable: false),
                    ApiId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Desription = table.Column<string>(type: "TEXT", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestTranslationMissing", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestTranslationMissing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentUpgradeIssues",
                table: "EquipmentUpgradeIssues");

            migrationBuilder.RenameTable(
                name: "EquipmentUpgradeIssues",
                newName: "EquipmentUpgradeIssuesController");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentUpgradeIssuesController",
                table: "EquipmentUpgradeIssuesController",
                column: "Id");
        }
    }
}
