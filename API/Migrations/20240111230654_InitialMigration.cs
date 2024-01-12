using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Auth_Email = table.Column<string>(type: "TEXT", nullable: false),
                    Auth_Password = table.Column<string>(type: "TEXT", nullable: false),
                    StripeId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DiscountType = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicableOrderType = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Percentage = table.Column<long>(type: "INTEGER", nullable: true),
                    Amount = table.Column<long>(type: "INTEGER", nullable: true),
                    Currency = table.Column<int>(type: "INTEGER", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsStackable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Auth_Email = table.Column<string>(type: "TEXT", nullable: false),
                    Auth_Password = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderType = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderAmount = table.Column<long>(type: "INTEGER", nullable: false),
                    OrderCurrency = table.Column<int>(type: "INTEGER", nullable: false),
                    TipAmount = table.Column<long>(type: "INTEGER", nullable: true),
                    TipCurrency = table.Column<int>(type: "INTEGER", nullable: true),
                    TipPaymentType = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<long>(type: "INTEGER", nullable: true),
                    Currency = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountInStock = table.Column<int>(type: "INTEGER", nullable: true),
                    StripeId = table.Column<string>(type: "TEXT", nullable: true),
                    OriginCountry = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Percentage = table.Column<int>(type: "INTEGER", nullable: true),
                    Amount = table.Column<long>(type: "INTEGER", nullable: true),
                    Currency = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDiscount",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DiscountId = table.Column<string>(type: "TEXT", nullable: false),
                    IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDiscount", x => new { x.CustomerId, x.DiscountId });
                    table.ForeignKey(
                        name: "FK_CustomerDiscount_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDiscount_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDiscount_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PaymentType = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentState = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<long>(type: "INTEGER", nullable: false),
                    Currency = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Pay = table.Column<long>(type: "INTEGER", nullable: false),
                    Currency = table.Column<int>(type: "INTEGER", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    StripeId = table.Column<string>(type: "TEXT", nullable: true),
                    ServiceOrderId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Orders_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.Id, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTimeSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsBooked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTimeSlots_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceTimeSlots_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceTimeSlots_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaxItem",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TaxId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxItem", x => new { x.ServiceId, x.ProductId, x.TaxId });
                    table.ForeignKey(
                        name: "FK_TaxItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxItem_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxItem_Taxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDiscount_DiscountId",
                table: "CustomerDiscount",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDiscount_OrderId",
                table: "CustomerDiscount",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceOrderId",
                table: "Services",
                column: "ServiceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTimeSlots_CustomerId",
                table: "ServiceTimeSlots",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTimeSlots_EmployeeId",
                table: "ServiceTimeSlots",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTimeSlots_ServiceId",
                table: "ServiceTimeSlots",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxItem_ProductId",
                table: "TaxItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxItem_TaxId",
                table: "TaxItem",
                column: "TaxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDiscount");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ServiceTimeSlots");

            migrationBuilder.DropTable(
                name: "TaxItem");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
