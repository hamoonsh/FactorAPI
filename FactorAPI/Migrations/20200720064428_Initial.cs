using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FactorAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pmwebsit_FactorDB");

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "pmwebsit_FactorDB",
                columns: table => new
                {
                    FactorID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(nullable: false),
                    RegDate = table.Column<DateTime>(nullable: false),
                    IsPayed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.FactorID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                schema: "pmwebsit_FactorDB",
                columns: table => new
                {
                    ItemID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<long>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    PricePerEach = table.Column<decimal>(nullable: false),
                    DiscountPercentage = table.Column<decimal>(nullable: false),
                    InvoiceID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalSchema: "pmwebsit_FactorDB",
                        principalTable: "Invoice",
                        principalColumn: "FactorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceID",
                schema: "pmwebsit_FactorDB",
                table: "InvoiceItem",
                column: "InvoiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItem",
                schema: "pmwebsit_FactorDB");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "pmwebsit_FactorDB");
        }
    }
}
