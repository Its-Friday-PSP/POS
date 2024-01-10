using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTimeSlots_Employees_Id",
                table: "ServiceTimeSlots",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Employees_Id",
                table: "ServiceTimeSlots");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "ServiceTimeSlots",
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
