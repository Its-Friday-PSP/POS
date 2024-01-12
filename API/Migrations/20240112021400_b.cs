using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TipAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TipCurrency",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Taxes",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Pay",
                table: "Services",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Payments",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "TipPaymentType",
                table: "Orders",
                newName: "Tip");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Discounts",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Taxes",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Services",
                newName: "Pay");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Payments",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "Tip",
                table: "Orders",
                newName: "TipPaymentType");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Discounts",
                newName: "Currency");

            migrationBuilder.AddColumn<long>(
                name: "Amount",
                table: "Taxes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Services",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Amount",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TipAmount",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipCurrency",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Amount",
                table: "Discounts",
                type: "INTEGER",
                nullable: true);
        }
    }
}
