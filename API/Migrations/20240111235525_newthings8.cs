using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class newthings8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaltyPoints",
                table: "Services");

            migrationBuilder.AddColumn<long>(
                name: "LoyaltyPoints",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoyaltyPoints",
                table: "Payments");

            migrationBuilder.AddColumn<long>(
                name: "LoaltyPoints",
                table: "Services",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
