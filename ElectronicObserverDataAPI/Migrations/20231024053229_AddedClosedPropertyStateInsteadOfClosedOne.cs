using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicObserverDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedClosedPropertyStateInsteadOfClosedOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Closed",
                table: "QuestTranslationMissing",
                newName: "IssueState");

            migrationBuilder.RenameColumn(
                name: "Closed",
                table: "EquipmentUpgradeIssues",
                newName: "IssueState");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IssueState",
                table: "QuestTranslationMissing",
                newName: "Closed");

            migrationBuilder.RenameColumn(
                name: "IssueState",
                table: "EquipmentUpgradeIssues",
                newName: "Closed");
        }
    }
}
