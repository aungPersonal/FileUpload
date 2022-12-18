using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileUpload.Migrations
{
    public partial class ConfigTransactionStatusData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ConfigTransactionStatus",
                columns: new[] { "Id", "CSVStatusName", "CreatedBy", "CreatedDateTime", "ShortName", "UpdatedBy", "UpdatedDateTime", "XMLStatusName" },
                values: new object[] { 1, "Approved", 1, new DateTime(2022, 12, 18, 19, 12, 46, 330, DateTimeKind.Unspecified), "A", null, null, "Approved" });

            migrationBuilder.InsertData(
                table: "ConfigTransactionStatus",
                columns: new[] { "Id", "CSVStatusName", "CreatedBy", "CreatedDateTime", "ShortName", "UpdatedBy", "UpdatedDateTime", "XMLStatusName" },
                values: new object[] { 2, "Failed", 1, new DateTime(2022, 12, 18, 19, 12, 46, 330, DateTimeKind.Unspecified), "R", null, null, "Rejected" });

            migrationBuilder.InsertData(
                table: "ConfigTransactionStatus",
                columns: new[] { "Id", "CSVStatusName", "CreatedBy", "CreatedDateTime", "ShortName", "UpdatedBy", "UpdatedDateTime", "XMLStatusName" },
                values: new object[] { 3, "Finished", 1, new DateTime(2022, 12, 18, 19, 12, 46, 330, DateTimeKind.Unspecified), "D", null, null, "Done" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConfigTransactionStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ConfigTransactionStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ConfigTransactionStatus",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
