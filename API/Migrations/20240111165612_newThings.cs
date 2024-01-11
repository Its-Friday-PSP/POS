using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class newThings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Services_Id",
                table: "ServiceTimeSlots");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTimeSlots_ServiceId",
                table: "ServiceTimeSlots",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTimeSlots_Services_ServiceId",
                table: "ServiceTimeSlots",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Services_ServiceId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTimeSlots_ServiceId",
                table: "ServiceTimeSlots");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTimeSlots_Services_Id",
                table: "ServiceTimeSlots",
                column: "Id",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
