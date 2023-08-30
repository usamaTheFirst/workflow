using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAPConnection.Migrations
{
    /// <inheritdoc />
    public partial class MinuteSheetTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "manualWorkFlows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinuteSheetID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalStages = table.Column<int>(type: "int", nullable: false),
                    OwnerPno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTask1 = table.Column<int>(type: "int", nullable: false),
                    Approver1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTask2 = table.Column<int>(type: "int", nullable: false),
                    Approver2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTask3 = table.Column<int>(type: "int", nullable: false),
                    Approver3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approver4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTask4 = table.Column<int>(type: "int", nullable: false),
                    Approver5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTask5 = table.Column<int>(type: "int", nullable: false),
                    Approver6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTask6 = table.Column<int>(type: "int", nullable: false),
                    Approver7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTask7 = table.Column<int>(type: "int", nullable: false),
                    Approver8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTask8 = table.Column<int>(type: "int", nullable: false),
                    Approver9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTask9 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manualWorkFlows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "minuteSheetCommits",
                columns: table => new
                {
                    CommitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinuteSheetID = table.Column<int>(type: "int", nullable: false),
                    ActionPerformed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommitOwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_minuteSheetCommits", x => x.CommitId);
                });

            migrationBuilder.CreateTable(
                name: "minuteSheetMarkReplyTable",
                columns: table => new
                {
                    MarkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinuteSheetID = table.Column<int>(type: "int", nullable: false),
                    CommitAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitOwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitOwnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_minuteSheetMarkReplyTable", x => x.MarkId);
                });

            migrationBuilder.CreateTable(
                name: "minuteSheetTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinuteSheetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LDAttachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_minuteSheetTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "manualWorkFlows");

            migrationBuilder.DropTable(
                name: "minuteSheetCommits");

            migrationBuilder.DropTable(
                name: "minuteSheetMarkReplyTable");

            migrationBuilder.DropTable(
                name: "minuteSheetTable");
        }
    }
}
