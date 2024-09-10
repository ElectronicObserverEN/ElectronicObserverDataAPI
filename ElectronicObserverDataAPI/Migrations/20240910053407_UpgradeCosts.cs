using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicObserverDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeCosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentUpgradeCostModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fuel = table.Column<int>(type: "INTEGER", nullable: false),
                    Ammo = table.Column<int>(type: "INTEGER", nullable: false),
                    Steel = table.Column<int>(type: "INTEGER", nullable: false),
                    Bauxite = table.Column<int>(type: "INTEGER", nullable: false),
                    DevmatCost = table.Column<int>(type: "INTEGER", nullable: false),
                    SliderDevmatCost = table.Column<int>(type: "INTEGER", nullable: false),
                    ImproveMatCost = table.Column<int>(type: "INTEGER", nullable: false),
                    SliderImproveMatCost = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUpgradeCostModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentUpgradeCostIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SoftwareVersion = table.Column<string>(type: "TEXT", nullable: false),
                    DataVersion = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpectedId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActualId = table.Column<int>(type: "INTEGER", nullable: false),
                    HelperId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    IssueState = table.Column<int>(type: "INTEGER", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUpgradeCostIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentUpgradeCostIssues_EquipmentUpgradeCostModel_ActualId",
                        column: x => x.ActualId,
                        principalTable: "EquipmentUpgradeCostModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentUpgradeCostIssues_EquipmentUpgradeCostModel_ExpectedId",
                        column: x => x.ExpectedId,
                        principalTable: "EquipmentUpgradeCostModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentUpgradeCostItemModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentUpgradeCostModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    EquipmentUpgradeCostModelId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUpgradeCostItemModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentUpgradeCostItemModel_EquipmentUpgradeCostModel_EquipmentUpgradeCostModelId",
                        column: x => x.EquipmentUpgradeCostModelId,
                        principalTable: "EquipmentUpgradeCostModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentUpgradeCostItemModel_EquipmentUpgradeCostModel_EquipmentUpgradeCostModelId1",
                        column: x => x.EquipmentUpgradeCostModelId1,
                        principalTable: "EquipmentUpgradeCostModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUpgradeCostIssues_ActualId",
                table: "EquipmentUpgradeCostIssues",
                column: "ActualId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUpgradeCostIssues_ExpectedId",
                table: "EquipmentUpgradeCostIssues",
                column: "ExpectedId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUpgradeCostItemModel_EquipmentUpgradeCostModelId",
                table: "EquipmentUpgradeCostItemModel",
                column: "EquipmentUpgradeCostModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUpgradeCostItemModel_EquipmentUpgradeCostModelId1",
                table: "EquipmentUpgradeCostItemModel",
                column: "EquipmentUpgradeCostModelId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentUpgradeCostIssues");

            migrationBuilder.DropTable(
                name: "EquipmentUpgradeCostItemModel");

            migrationBuilder.DropTable(
                name: "EquipmentUpgradeCostModel");
        }
    }
}
