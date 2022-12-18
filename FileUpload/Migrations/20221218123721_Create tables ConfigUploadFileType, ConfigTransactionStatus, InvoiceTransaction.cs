using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileUpload.Migrations
{
    public partial class CreatetablesConfigUploadFileTypeConfigTransactionStatusInvoiceTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigTransactionStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CSVStatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XMLStatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigTransactionStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigUploadFileType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigUploadFileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTransaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfigTransactionStatusId = table.Column<int>(type: "int", nullable: false),
                    UploadedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadedGpSerialNo = table.Column<long>(type: "bigint", nullable: false),
                    ConfigUploadFileTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceTransaction_ConfigTransactionStatus_ConfigTransactionStatusId",
                        column: x => x.ConfigTransactionStatusId,
                        principalTable: "ConfigTransactionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceTransaction_ConfigUploadFileType_ConfigUploadFileTypeId",
                        column: x => x.ConfigUploadFileTypeId,
                        principalTable: "ConfigUploadFileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTransaction_ConfigTransactionStatusId",
                table: "InvoiceTransaction",
                column: "ConfigTransactionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTransaction_ConfigUploadFileTypeId",
                table: "InvoiceTransaction",
                column: "ConfigUploadFileTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceTransaction");

            migrationBuilder.DropTable(
                name: "ConfigTransactionStatus");

            migrationBuilder.DropTable(
                name: "ConfigUploadFileType");
        }
    }
}
