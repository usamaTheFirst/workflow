using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAPConnection.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "changeManagementCommits",
                columns: table => new
                {
                    CommitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeManagementID = table.Column<int>(type: "int", nullable: false),
                    ActionPerformed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommitOwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_changeManagementCommits", x => x.CommitId);
                });

            migrationBuilder.CreateTable(
                name: "changeManagementTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedChange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamDependency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatChange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Impact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RollBack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    table.PrimaryKey("PK_changeManagementTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dataCenterCommits",
                columns: table => new
                {
                    CommitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCenterID = table.Column<int>(type: "int", nullable: false),
                    ActionPerformed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommitOwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataCenterCommits", x => x.CommitId);
                });

            migrationBuilder.CreateTable(
                name: "dataCenterTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetworksStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetworksRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SANStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SANRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOCStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOCRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_dataCenterTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employeeReferralTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVAttachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    table.PrimaryKey("PK_employeeReferralTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "facilityManagementCommits",
                columns: table => new
                {
                    CommitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityManagementID = table.Column<int>(type: "int", nullable: false),
                    ActionPerformed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommitOwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facilityManagementCommits", x => x.CommitId);
                });

            migrationBuilder.CreateTable(
                name: "facilityManagementTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForLate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DCIMStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DCIMRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRACStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRACRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FireRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DCUPSStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DCUPSRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICTUPSStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICTUPSRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_facilityManagementTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lateSittingCommits",
                columns: table => new
                {
                    CommitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LateSittingID = table.Column<int>(type: "int", nullable: false),
                    ActionPerformed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommitOwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lateSittingCommits", x => x.CommitId);
                });

            migrationBuilder.CreateTable(
                name: "lateSittingTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    table.PrimaryKey("PK_lateSittingTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "changeManagementCommits");

            migrationBuilder.DropTable(
                name: "changeManagementTable");

            migrationBuilder.DropTable(
                name: "dataCenterCommits");

            migrationBuilder.DropTable(
                name: "dataCenterTable");

            migrationBuilder.DropTable(
                name: "employeeReferralTable");

            migrationBuilder.DropTable(
                name: "facilityManagementCommits");

            migrationBuilder.DropTable(
                name: "facilityManagementTable");

            migrationBuilder.DropTable(
                name: "lateSittingCommits");

            migrationBuilder.DropTable(
                name: "lateSittingTable");
        }
    }
}
