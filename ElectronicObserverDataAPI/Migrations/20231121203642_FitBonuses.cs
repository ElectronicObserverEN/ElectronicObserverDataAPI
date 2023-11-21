using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicObserverDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class FitBonuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FitBonusValueModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firepower = table.Column<int>(type: "INTEGER", nullable: false),
                    Torpedo = table.Column<int>(type: "INTEGER", nullable: false),
                    AntiAir = table.Column<int>(type: "INTEGER", nullable: false),
                    Armor = table.Column<int>(type: "INTEGER", nullable: false),
                    Evasion = table.Column<int>(type: "INTEGER", nullable: false),
                    ASW = table.Column<int>(type: "INTEGER", nullable: false),
                    LOS = table.Column<int>(type: "INTEGER", nullable: false),
                    Accuracy = table.Column<int>(type: "INTEGER", nullable: false),
                    Range = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitBonusValueModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShipId = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Firepower = table.Column<int>(type: "INTEGER", nullable: false),
                    Torpedo = table.Column<int>(type: "INTEGER", nullable: false),
                    AntiAir = table.Column<int>(type: "INTEGER", nullable: false),
                    Armor = table.Column<int>(type: "INTEGER", nullable: false),
                    Evasion = table.Column<int>(type: "INTEGER", nullable: false),
                    ASW = table.Column<int>(type: "INTEGER", nullable: false),
                    LOS = table.Column<int>(type: "INTEGER", nullable: false),
                    Accuracy = table.Column<int>(type: "INTEGER", nullable: false),
                    Range = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitBonusIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SoftwareVersion = table.Column<string>(type: "TEXT", nullable: false),
                    DataVersion = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpectedBonusId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActualBonusId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShipId = table.Column<int>(type: "INTEGER", nullable: false),
                    IssueState = table.Column<int>(type: "INTEGER", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitBonusIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitBonusIssues_FitBonusValueModel_ActualBonusId",
                        column: x => x.ActualBonusId,
                        principalTable: "FitBonusValueModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitBonusIssues_FitBonusValueModel_ExpectedBonusId",
                        column: x => x.ExpectedBonusId,
                        principalTable: "FitBonusValueModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitBonusIssues_ShipModel_ShipId",
                        column: x => x.ShipId,
                        principalTable: "ShipModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    FitBonusIssueModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentModel_FitBonusIssues_FitBonusIssueModelId",
                        column: x => x.FitBonusIssueModelId,
                        principalTable: "FitBonusIssues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentModel_FitBonusIssueModelId",
                table: "EquipmentModel",
                column: "FitBonusIssueModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FitBonusIssues_ActualBonusId",
                table: "FitBonusIssues",
                column: "ActualBonusId");

            migrationBuilder.CreateIndex(
                name: "IX_FitBonusIssues_ExpectedBonusId",
                table: "FitBonusIssues",
                column: "ExpectedBonusId");

            migrationBuilder.CreateIndex(
                name: "IX_FitBonusIssues_ShipId",
                table: "FitBonusIssues",
                column: "ShipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentModel");

            migrationBuilder.DropTable(
                name: "FitBonusIssues");

            migrationBuilder.DropTable(
                name: "FitBonusValueModel");

            migrationBuilder.DropTable(
                name: "ShipModel");
        }
    }
}
