using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAPConnection.Migrations
{
    /// <inheritdoc />
    public partial class chagesinfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChangeManagementID",
                table: "positionRequisitionFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeReferralID",
                table: "positionRequisitionFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LateSittingID",
                table: "positionRequisitionFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinuteSheetID",
                table: "positionRequisitionFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeManagementID",
                table: "positionRequisitionFiles");

            migrationBuilder.DropColumn(
                name: "EmployeeReferralID",
                table: "positionRequisitionFiles");

            migrationBuilder.DropColumn(
                name: "LateSittingID",
                table: "positionRequisitionFiles");

            migrationBuilder.DropColumn(
                name: "MinuteSheetID",
                table: "positionRequisitionFiles");
        }
    }
}
