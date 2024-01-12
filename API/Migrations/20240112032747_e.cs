using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class e : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxItem_Products_ProductId",
                table: "TaxItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxItem_Services_ServiceId",
                table: "TaxItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxItem",
                table: "TaxItem");

            migrationBuilder.DropIndex(
                name: "IX_TaxItem_ServiceId",
                table: "TaxItem");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TaxItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "TaxItem",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "TaxItem",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxItem",
                table: "TaxItem",
                columns: new[] { "ServiceId", "ProductId", "TaxId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TaxItem_Products_ProductId",
                table: "TaxItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxItem_Services_ServiceId",
                table: "TaxItem",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxItem_Products_ProductId",
                table: "TaxItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxItem_Services_ServiceId",
                table: "TaxItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxItem",
                table: "TaxItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "TaxItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "TaxItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TaxItem",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxItem",
                table: "TaxItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TaxItem_ServiceId",
                table: "TaxItem",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxItem_Products_ProductId",
                table: "TaxItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxItem_Services_ServiceId",
                table: "TaxItem",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
