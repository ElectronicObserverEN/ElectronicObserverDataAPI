using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicObserverDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class DbFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentUpgradeCostItemModel",
                table: "EquipmentUpgradeCostItemModel");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EquipmentUpgradeCostItemModel",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "EoApiId",
                table: "EquipmentUpgradeCostItemModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentUpgradeCostItemModel",
                table: "EquipmentUpgradeCostItemModel",
                column: "EoApiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentUpgradeCostItemModel",
                table: "EquipmentUpgradeCostItemModel");

            migrationBuilder.DropColumn(
                name: "EoApiId",
                table: "EquipmentUpgradeCostItemModel");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EquipmentUpgradeCostItemModel",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentUpgradeCostItemModel",
                table: "EquipmentUpgradeCostItemModel",
                column: "Id");
        }
    }
}
