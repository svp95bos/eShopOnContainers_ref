using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedbackReplyMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackReplyMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    PublicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    POBox = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    WorkPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    DataValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom"),
                    DataValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackReports", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");

            migrationBuilder.CreateTable(
                name: "FeedbackReportFeedbackReportReplyMethod",
                columns: table => new
                {
                    FeedbackReportsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyMethodsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackReportFeedbackReportReplyMethod", x => new { x.FeedbackReportsId, x.ReplyMethodsId });
                    table.ForeignKey(
                        name: "FK_FeedbackReportFeedbackReportReplyMethod_FeedbackReplyMethods_ReplyMethodsId",
                        column: x => x.ReplyMethodsId,
                        principalTable: "FeedbackReplyMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackReportFeedbackReportReplyMethod_FeedbackReports_FeedbackReportsId",
                        column: x => x.FeedbackReportsId,
                        principalTable: "FeedbackReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackReportFeedbackReportReplyMethod_ReplyMethodsId",
                table: "FeedbackReportFeedbackReportReplyMethod",
                column: "ReplyMethodsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackReportFeedbackReportReplyMethod");

            migrationBuilder.DropTable(
                name: "FeedbackReplyMethods");

            migrationBuilder.DropTable(
                name: "FeedbackReports")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "FeedbackReportsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "DataValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "DataValidFrom");
        }
    }
}
