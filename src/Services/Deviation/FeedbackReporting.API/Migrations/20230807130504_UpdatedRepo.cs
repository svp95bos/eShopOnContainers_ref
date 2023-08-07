using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRepo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "feedbackreporting");

            migrationBuilder.RenameTable(
                name: "FeedbackReports",
                newName: "FeedbackReports",
                newSchema: "feedbackreporting")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.RenameTable(
                name: "FeedbackReportFeedbackReportReplyMethod",
                newName: "FeedbackReportFeedbackReportReplyMethod",
                newSchema: "feedbackreporting");

            migrationBuilder.RenameTable(
                name: "FeedbackReplyMethods",
                newName: "FeedbackReplyMethods",
                newSchema: "feedbackreporting");

            migrationBuilder.AlterTable(
                name: "FeedbackReports",
                schema: "feedbackreporting")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "WorkPhone",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedBy",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Updated",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<int>(
                name: "PublicId",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "POBox",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<bool>(
                name: "IsReadOnly",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataValidTo",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataValidFrom",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "feedbackreporting",
                table: "FeedbackReports",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "FeedbackReports",
                schema: "feedbackreporting",
                newName: "FeedbackReports")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting");

            migrationBuilder.RenameTable(
                name: "FeedbackReportFeedbackReportReplyMethod",
                schema: "feedbackreporting",
                newName: "FeedbackReportFeedbackReportReplyMethod");

            migrationBuilder.RenameTable(
                name: "FeedbackReplyMethods",
                schema: "feedbackreporting",
                newName: "FeedbackReplyMethods");

            migrationBuilder.AlterTable(
                name: "FeedbackReports")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "WorkPhone",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedBy",
                table: "FeedbackReports",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Updated",
                table: "FeedbackReports",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<int>(
                name: "PublicId",
                table: "FeedbackReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "POBox",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<bool>(
                name: "IsReadOnly",
                table: "FeedbackReports",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataValidTo",
                table: "FeedbackReports",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataValidFrom",
                table: "FeedbackReports",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "FeedbackReports",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "FeedbackReports",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "FeedbackReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "FeedbackReports",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "feedbackreporting")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");
        }
    }
}
