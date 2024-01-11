using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class newthings2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Customers_CustomerId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Employees_EmployeeId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Services_ServiceId",
                table: "ServiceTimeSlots");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "ServiceTimeSlots",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "ServiceTimeSlots",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "ServiceTimeSlots",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTimeSlots_Customers_CustomerId",
                table: "ServiceTimeSlots",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTimeSlots_Employees_EmployeeId",
                table: "ServiceTimeSlots",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTimeSlots_Services_ServiceId",
                table: "ServiceTimeSlots",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Customers_CustomerId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Employees_EmployeeId",
                table: "ServiceTimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTimeSlots_Services_ServiceId",
                table: "ServiceTimeSlots");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceId",
                table: "ServiceTimeSlots",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "ServiceTimeSlots",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "ServiceTimeSlots",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTimeSlots_Customers_CustomerId",
                table: "ServiceTimeSlots",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
