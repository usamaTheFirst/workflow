﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SAPConnection.Data;

#nullable disable

namespace SAPConnection.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230818050242_includedShiftGroup")]
    partial class includedShiftGroup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SAPConnection.Data.ApplicationUser", b =>
                {
                    b.Property<int>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Uid"));

                    b.Property<bool>("Acting")
                        .HasColumnType("bit");

                    b.Property<string>("ActingPno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesignationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShiftGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Uid");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("SAPConnection.Data.ApproversModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentHeadId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FunctionalHeadId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SapId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionHeadId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitManagerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Approvers");
                });

            modelBuilder.Entity("SAPConnection.Data.BatchRegularizationData.BatchCommit", b =>
                {
                    b.Property<int>("CommitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommitId"));

                    b.Property<string>("ActionPerformed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BatchRegularizationID")
                        .HasColumnType("int");

                    b.Property<string>("CommitMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("CommitId");

                    b.ToTable("BatchCommits");
                });

            modelBuilder.Entity("SAPConnection.Data.BatchRegularizationData.BatchRegularizationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentActioner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrentStage")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerPno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalStages")
                        .HasColumnType("int");

                    b.Property<int>("approvalStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BatchRegularizations");
                });

            modelBuilder.Entity("SAPConnection.Data.LeaveData.CommitTrailItem", b =>
                {
                    b.Property<int>("CommitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommitId"));

                    b.Property<string>("ActionPerformed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaveId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("CommitId");

                    b.ToTable("CommitTrails");
                });

            modelBuilder.Entity("SAPConnection.Data.LeaveData.LeaveModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("AvailedDays")
                        .HasColumnType("int");

                    b.Property<string>("CurrentActioner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrentStage")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LeaveBalance")
                        .HasColumnType("int");

                    b.Property<string>("LeaveOwnerPno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaveType")
                        .HasColumnType("int");

                    b.Property<int?>("PreviousLeaveId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonForCancellation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TotalStages")
                        .HasColumnType("int");

                    b.Property<int>("approvalStatus")
                        .HasColumnType("int");

                    b.Property<int>("postedToSap")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("leaveModel");
                });

            modelBuilder.Entity("SAPConnection.Data.ManualWorkFlow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Approver1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Approver2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Approver3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Approver4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Approver5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Approver6")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Approver7")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Approver8")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Approver9")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssignedTask1")
                        .HasColumnType("int");

                    b.Property<int>("AssignedTask2")
                        .HasColumnType("int");

                    b.Property<int>("AssignedTask3")
                        .HasColumnType("int");

                    b.Property<int>("AssignedTask4")
                        .HasColumnType("int");

                    b.Property<int>("AssignedTask5")
                        .HasColumnType("int");

                    b.Property<int>("AssignedTask6")
                        .HasColumnType("int");

                    b.Property<int>("AssignedTask7")
                        .HasColumnType("int");

                    b.Property<int>("AssignedTask8")
                        .HasColumnType("int");

                    b.Property<int>("AssignedTask9")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MinuteSheetID")
                        .HasColumnType("int");

                    b.Property<string>("OwnerPno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalStages")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("manualWorkFlows");
                });

            modelBuilder.Entity("SAPConnection.Data.MinuteSheetData.MinuteSheetCommitsItems", b =>
                {
                    b.Property<int>("CommitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommitId"));

                    b.Property<string>("ActionPerformed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinuteSheetID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("CommitId");

                    b.ToTable("minuteSheetCommits");
                });

            modelBuilder.Entity("SAPConnection.Data.MinuteSheetData.MinuteSheetModels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrentActioner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrentStage")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("LDAttachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("MinuteSheetType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerPno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalStages")
                        .HasColumnType("int");

                    b.Property<int>("approvalStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("minuteSheetTable");
                });

            modelBuilder.Entity("SAPConnection.Data.MinuteSheetData.MinuteSheetReplyModel", b =>
                {
                    b.Property<int>("MarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkId"));

                    b.Property<string>("CommitAction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarkEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarkType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinuteSheetID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarkId");

                    b.ToTable("minuteSheetMarkReplyTable");
                });

            modelBuilder.Entity("SAPConnection.Data.POCommitTrailItem", b =>
                {
                    b.Property<int>("CommitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommitId"));

                    b.Property<string>("ActionPerformed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("POId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("CommitId");

                    b.ToTable("POCommitTrails");
                });

            modelBuilder.Entity("SAPConnection.Data.PaymentOrder.PaymentOrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CostCenter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentActioner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrentStage")
                        .HasColumnType("int");

                    b.Property<string>("GeneralLedger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Internal_Order")
                        .HasColumnType("float");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NatureModel")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentOrderDetail")
                        .HasColumnType("int");

                    b.Property<string>("PaymentOrderOwnerPno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int?>("TotalStages")
                        .HasColumnType("int");

                    b.Property<double?>("WBS")
                        .HasColumnType("float");

                    b.Property<int>("approvalStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PaymentOrderModels");
                });

            modelBuilder.Entity("SAPConnection.Data.RegularizationData.RegularizationCommitsItems", b =>
                {
                    b.Property<int>("CommitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommitId"));

                    b.Property<string>("ActionPerformed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegularizationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("CommitId");

                    b.ToTable("RegularizationCommits");
                });

            modelBuilder.Entity("SAPConnection.Data.RegularizationData.RegularizationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrentActioner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrentStage")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Justification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerPno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeEventType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalStages")
                        .HasColumnType("int");

                    b.Property<int>("approvalStatus")
                        .HasColumnType("int");

                    b.Property<int?>("batchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RegularizationTable");
                });

            modelBuilder.Entity("SAPConnection.Data.ShiftInchargeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApproversId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShiftInchargePno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShiftType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShiftIncharge");
                });

            modelBuilder.Entity("SAPConnection.Data.StaticApproversModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StaticApproversModels");
                });

            modelBuilder.Entity("SAPConnection.Data.VRCommitTrailItem", b =>
                {
                    b.Property<int>("CommitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommitId"));

                    b.Property<string>("ActionPerformed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommitOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("VRId")
                        .HasColumnType("int");

                    b.HasKey("CommitId");

                    b.ToTable("VRCommitTrails");
                });

            modelBuilder.Entity("SAPConnection.Data.VisitRegularizationData.VisitRegularization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CurrentActioner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrentStage")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_To")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerPno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TotalStages")
                        .HasColumnType("int");

                    b.Property<int>("Visit_Type")
                        .HasColumnType("int");

                    b.Property<int>("approvalStatus")
                        .HasColumnType("int");

                    b.Property<int>("postedToSap")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VisitRegularization");
                });

            modelBuilder.Entity("SAPConnection.Data.WorkflowItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("App")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ApproverRole")
                        .HasColumnType("int");

                    b.Property<int?>("ApproverType")
                        .HasColumnType("int");

                    b.Property<int>("AssignedTask")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaticApproverRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WF_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("specific_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workflows");
                });
#pragma warning restore 612, 618
        }
    }
}
