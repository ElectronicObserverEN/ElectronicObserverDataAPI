using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicObserverDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddShipStatDeterminedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ASWDetermined",
                table: "ShipModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EvasionDetermined",
                table: "ShipModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LOSDetermined",
                table: "ShipModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ASWDetermined",
                table: "ShipModel");

            migrationBuilder.DropColumn(
                name: "EvasionDetermined",
                table: "ShipModel");

            migrationBuilder.DropColumn(
                name: "LOSDetermined",
                table: "ShipModel");
        }
    }
}
