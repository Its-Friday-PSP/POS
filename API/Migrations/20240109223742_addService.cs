using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Orders_Id",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Employees_Id",
                table: "ServiceTimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Services_Id",
                table: "ServiceTimeSlots");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "ServiceTimeSlots",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId",
                table: "ServiceTimeSlots",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceOrderId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTimeSlots_EmployeeId",
                table: "ServiceTimeSlots",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTimeSlots_ServiceId",
                table: "ServiceTimeSlots",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceOrderId",
                table: "Services",
                column: "ServiceOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Orders_ServiceOrderId",
                table: "Services",
                column: "ServiceOrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTimeSlots_Employees_EmployeeId",
                table: "ServiceTimeSlots",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Services_Orders_ServiceOrderId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Employees_EmployeeId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Services_ServiceId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTimeSlots_EmployeeId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTimeSlots_ServiceId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceOrderId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropColumn(
                name: "ServiceOrderId",
                table: "Services");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Orders_Id",
                table: "Services",
                column: "Id",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTimeSlots_Employees_Id",
                table: "ServiceTimeSlots",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
