using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAPConnection.Migrations
{
    /// <inheritdoc />
    public partial class VisitRegularizationTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentActioner",
                table: "VisitRegularization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStage",
                table: "VisitRegularization",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "VisitRegularization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerPno",
                table: "VisitRegularization",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalStages",
                table: "VisitRegularization",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "approvalStatus",
                table: "VisitRegularization",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentActioner",
                table: "VisitRegularization");

            migrationBuilder.DropColumn(
                name: "CurrentStage",
                table: "VisitRegularization");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "VisitRegularization");

            migrationBuilder.DropColumn(
                name: "OwnerPno",
                table: "VisitRegularization");

            migrationBuilder.DropColumn(
                name: "TotalStages",
                table: "VisitRegularization");

            migrationBuilder.DropColumn(
                name: "approvalStatus",
                table: "VisitRegularization");
        }
    }
}
