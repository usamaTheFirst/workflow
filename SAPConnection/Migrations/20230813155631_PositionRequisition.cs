using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAPConnection.Migrations
{
    /// <inheritdoc />
    public partial class PositionRequisition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_minuteSheetCommits",
                table: "minuteSheetCommits");

            migrationBuilder.RenameTable(
                name: "minuteSheetCommits",
                newName: "MinuteSheetCommits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MinuteSheetCommits",
                table: "MinuteSheetCommits",
                column: "CommitId");

            migrationBuilder.CreateTable(
                name: "positionRequisitionCommits",
                columns: table => new
                {
                    CommitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionRequisitionID = table.Column<int>(type: "int", nullable: false),
                    ActionPerformed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommitOwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positionRequisitionCommits", x => x.CommitId);
                });

            migrationBuilder.CreateTable(
                name: "positionRequisitionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacementPno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurposeForPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    JDAttachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerPno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    approvalStatus = table.Column<int>(type: "int", nullable: false),
                    TotalStages = table.Column<int>(type: "int", nullable: true),
                    CurrentActioner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStage = table.Column<int>(type: "int", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positionRequisitionTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "positionRequisitionCommits");

            migrationBuilder.DropTable(
                name: "positionRequisitionTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MinuteSheetCommits",
                table: "MinuteSheetCommits");

            migrationBuilder.RenameTable(
                name: "MinuteSheetCommits",
                newName: "minuteSheetCommits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_minuteSheetCommits",
                table: "minuteSheetCommits",
                column: "CommitId");
        }
    }
}
