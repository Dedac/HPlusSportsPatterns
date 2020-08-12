using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HPlusSports.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    ProductCode = table.Column<string>(maxLength: 10, nullable: false),
                    ProductName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Size = table.Column<int>(nullable: true),
                    Variety = table.Column<string>(type: "varchar(50)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    Perishable = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    ExpirationDays = table.Column<int>(nullable: true),
                    Refrigerated = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.UniqueConstraint("AK_Product_ProductCode", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "SalesGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesGroup", x => x.Id);
                    table.UniqueConstraint("AK_SalesGroup_State_Type", x => new { x.State, x.Type });
                });

            migrationBuilder.CreateTable(
                name: "Salesperson",
                columns: table => new
                {
                    SalespersonID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(50)", nullable: true),
                    SalesGroupState = table.Column<string>(maxLength: 2, nullable: false, defaultValue: "CA"),
                    SalesGroupType = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "varchar(50)", nullable: true),
                    City = table.Column<string>(type: "varchar(50)", nullable: true),
                    State = table.Column<string>(type: "varchar(50)", nullable: true),
                    Zipcode = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesperson", x => x.SalespersonID);
                    table.ForeignKey(
                        name: "FK_Salesperson_SalesGroup_SalesGroupState_SalesGroupType",
                        columns: x => new { x.SalesGroupState, x.SalesGroupType },
                        principalTable: "SalesGroup",
                        principalColumns: new[] { "State", "Type" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    TotalDue = table.Column<decimal>(type: "money", nullable: true),
                    Status = table.Column<string>(nullable: false, defaultValueSql: "'none'"),
                    CustomerID = table.Column<int>(nullable: false),
                    SalespersonID = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Customer",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Salesperson",
                        column: x => x.SalespersonID,
                        principalTable: "Salesperson",
                        principalColumn: "SalespersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<string>(maxLength: 10, nullable: false),
                    Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product1",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_LastName",
                table: "Customer",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order",
                table: "Order",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SalespersonID",
                table: "Order",
                column: "SalespersonID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductID",
                table: "OrderItem",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_StateType",
                table: "SalesGroup",
                columns: new[] { "State", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salesperson_SalesGroupState_SalesGroupType",
                table: "Salesperson",
                columns: new[] { "SalesGroupState", "SalesGroupType" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Salesperson");

            migrationBuilder.DropTable(
                name: "SalesGroup");
        }
    }
}
