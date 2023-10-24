using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicObserverDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedClosedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "QuestTranslationMissing",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "EquipmentUpgradeIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Closed",
                table: "QuestTranslationMissing");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "EquipmentUpgradeIssues");
        }
    }
}
