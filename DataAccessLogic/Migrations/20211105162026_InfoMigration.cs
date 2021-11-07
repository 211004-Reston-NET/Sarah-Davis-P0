using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLogic.Migrations
{
    public partial class InfoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    customer_address = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    customer_email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    customer_phone_number = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    customer_password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "storefront",
                columns: table => new
                {
                    storefront_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storefront_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    storefront_address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storefront", x => x.storefront_id);
                });

            migrationBuilder.CreateTable(
                name: "order_page",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineItemId = table.Column<int>(type: "int", nullable: true),
                    LineItemOrderId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StoreLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    order_storelocation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    order_totalprice = table.Column<decimal>(type: "money", nullable: true),
                    storefront_id = table.Column<int>(type: "int", nullable: true),
                    CustomerId1 = table.Column<int>(type: "int", nullable: true),
                    StoreFrontId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_pa__46596229F5810271", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__order_pag__custo__693CA210",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__order_pag__store__68487DD7",
                        column: x => x.storefront_id,
                        principalTable: "storefront",
                        principalColumn: "storefront_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_page_customer_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_page_storefront_StoreFrontId",
                        column: x => x.StoreFrontId,
                        principalTable: "storefront",
                        principalColumn: "storefront_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineItemId = table.Column<int>(type: "int", nullable: false),
                    product_category = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    product_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    product_price = table.Column<decimal>(type: "money", nullable: true),
                    product_description = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    StoreFrontId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_product_storefront_StoreFrontId",
                        column: x => x.StoreFrontId,
                        principalTable: "storefront",
                        principalColumn: "storefront_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "line_item",
                columns: table => new
                {
                    line_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    line_item_quantity = table.Column<int>(type: "int", nullable: false),
                    storefront_id = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_line_item", x => x.line_item_id);
                    table.ForeignKey(
                        name: "FK__line_item__produ__6477ECF3",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__line_item__store__656C112C",
                        column: x => x.storefront_id,
                        principalTable: "storefront",
                        principalColumn: "storefront_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_line_item_order_page_OrderId",
                        column: x => x.OrderId,
                        principalTable: "order_page",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "line_item_order",
                columns: table => new
                {
                    line_item_order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    line_item_id = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_line_item_order", x => x.line_item_order_id);
                    table.ForeignKey(
                        name: "FK__line_item__line___6C190EBB",
                        column: x => x.line_item_id,
                        principalTable: "line_item",
                        principalColumn: "line_item_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__line_item__order__6D0D32F4",
                        column: x => x.order_id,
                        principalTable: "order_page",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_line_item_OrderId",
                table: "line_item",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_line_item_product_id",
                table: "line_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_line_item_storefront_id",
                table: "line_item",
                column: "storefront_id");

            migrationBuilder.CreateIndex(
                name: "IX_line_item_order_line_item_id",
                table: "line_item_order",
                column: "line_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_line_item_order_order_id",
                table: "line_item_order",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_page_customer_id",
                table: "order_page",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_page_CustomerId1",
                table: "order_page",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_order_page_storefront_id",
                table: "order_page",
                column: "storefront_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_page_StoreFrontId",
                table: "order_page",
                column: "StoreFrontId");

            migrationBuilder.CreateIndex(
                name: "IX_product_StoreFrontId",
                table: "product",
                column: "StoreFrontId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "line_item_order");

            migrationBuilder.DropTable(
                name: "line_item");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "order_page");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "storefront");
        }
    }
}
