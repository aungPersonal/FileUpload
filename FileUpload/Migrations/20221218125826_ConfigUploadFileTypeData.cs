using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileUpload.Migrations
{
    public partial class ConfigUploadFileTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ConfigUploadFileType",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "Name", "UpdatedBy", "UpdatedDateTime" },
                values: new object[] { 1, 1, new DateTime(2022, 12, 18, 19, 12, 46, 330, DateTimeKind.Unspecified), "CSV", null, null });

            migrationBuilder.InsertData(
                table: "ConfigUploadFileType",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "Name", "UpdatedBy", "UpdatedDateTime" },
                values: new object[] { 2, 1, new DateTime(2022, 12, 18, 19, 12, 46, 330, DateTimeKind.Unspecified), "XML", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConfigUploadFileType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ConfigUploadFileType",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
