using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeIdToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "ServiceTimeSlots",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTimeSlots_EmployeeId",
                table: "ServiceTimeSlots",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTimeSlots_Employees_EmployeeId",
                table: "ServiceTimeSlots",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Employees_EmployeeId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTimeSlots_EmployeeId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Orders");
        }
    }
}
