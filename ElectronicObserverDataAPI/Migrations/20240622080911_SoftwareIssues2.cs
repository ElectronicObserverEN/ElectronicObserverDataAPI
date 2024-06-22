using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicObserverDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class SoftwareIssues2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareIssues_SoftwareIssues_SoftwareIssueModelId",
                table: "SoftwareIssues");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareIssues_SoftwareIssueModelId",
                table: "SoftwareIssues");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "SoftwareIssues");

            migrationBuilder.DropColumn(
                name: "SoftwareIssueModelId",
                table: "SoftwareIssues");

            migrationBuilder.DropColumn(
                name: "StackTrace",
                table: "SoftwareIssues");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SoftwareIssues");

            migrationBuilder.AddColumn<int>(
                name: "ExceptionId",
                table: "SoftwareIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SoftwareExceptionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    StackTrace = table.Column<string>(type: "TEXT", nullable: false),
                    SoftwareExceptionModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareExceptionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareExceptionModel_SoftwareExceptionModel_SoftwareExceptionModelId",
                        column: x => x.SoftwareExceptionModelId,
                        principalTable: "SoftwareExceptionModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareIssues_ExceptionId",
                table: "SoftwareIssues",
                column: "ExceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareExceptionModel_SoftwareExceptionModelId",
                table: "SoftwareExceptionModel",
                column: "SoftwareExceptionModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareIssues_SoftwareExceptionModel_ExceptionId",
                table: "SoftwareIssues",
                column: "ExceptionId",
                principalTable: "SoftwareExceptionModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareIssues_SoftwareExceptionModel_ExceptionId",
                table: "SoftwareIssues");

            migrationBuilder.DropTable(
                name: "SoftwareExceptionModel");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareIssues_ExceptionId",
                table: "SoftwareIssues");

            migrationBuilder.DropColumn(
                name: "ExceptionId",
                table: "SoftwareIssues");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "SoftwareIssues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SoftwareIssueModelId",
                table: "SoftwareIssues",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StackTrace",
                table: "SoftwareIssues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SoftwareIssues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareIssues_SoftwareIssueModelId",
                table: "SoftwareIssues",
                column: "SoftwareIssueModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareIssues_SoftwareIssues_SoftwareIssueModelId",
                table: "SoftwareIssues",
                column: "SoftwareIssueModelId",
                principalTable: "SoftwareIssues",
                principalColumn: "Id");
        }
    }
}
