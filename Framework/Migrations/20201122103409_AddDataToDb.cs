using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Migrations
{
    public partial class AddDataToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ADMIN_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    PASSWD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MARK = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ADMIN_ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CATE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATE_NAME = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    CATE_IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CATE_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MARK = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    CODE_ID = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    CODE_NAME = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    PERCENTS = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MARK = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.CODE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Oders",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDER_DATE = table.Column<int>(type: "int", nullable: false),
                    PHONE = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    ADDRESS = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    PAYMENT_TYPE = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TOTAL_PRICE = table.Column<decimal>(type: "money", nullable: false),
                    RECEIVED = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DELIVERED = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oders", x => x.ORDER_ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MENU_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MENU_NAME = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    MENU_SIZE = table.Column<int>(type: "int", nullable: false),
                    MENU_PRICE = table.Column<decimal>(type: "money", nullable: false),
                    CALORIES = table.Column<float>(type: "real", nullable: false),
                    MENU_IMG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MENU_DESCRIPTION = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    MARK = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CATE_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MENU_ID);
                    table.ForeignKey(
                        name: "FK_Menus_Categories_CATE_ID",
                        column: x => x.CATE_ID,
                        principalTable: "Categories",
                        principalColumn: "CATE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_Details",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(type: "int", nullable: false),
                    MENU_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CODE_ID = table.Column<string>(type: "VARCHAR(15)", nullable: true, defaultValue: "null"),
                    MARK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => new { x.ORDER_ID, x.MENU_ID });
                    table.ForeignKey(
                        name: "FK_Order_Details_Discounts_CODE_ID",
                        column: x => x.CODE_ID,
                        principalTable: "Discounts",
                        principalColumn: "CODE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Details_Menus_MENU_ID",
                        column: x => x.MENU_ID,
                        principalTable: "Menus",
                        principalColumn: "MENU_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Details_Oders_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "Oders",
                        principalColumn: "ORDER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ADMIN_ID", "PASSWD", "USERNAME" },
                values: new object[] { 7, "123", "ducanhdeptraivodichvutru" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CATE_ID", "CATE_DESCRIPTION", "CATE_IMG", "CATE_NAME" },
                values: new object[,]
                {
                    { 1, "Gồm nhiều chất xơ và vitamin hỗ trợ giảm cân", "https://ibb.co/XF73tQf", "Món rau" },
                    { 2, "Gồm nhiều vitamin và dưỡng chất", "https://ibb.co/Gc11tnM", "Trái cây" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "CODE_ID", "CODE_NAME", "MARK", "PERCENTS" },
                values: new object[] { "BLACKFRIDAY", "Thứ sáu đen tối", 1, 50 });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MENU_ID", "CALORIES", "CATE_ID", "MENU_DESCRIPTION", "MENU_IMG", "MENU_NAME", "MENU_PRICE", "MENU_SIZE" },
                values: new object[,]
                {
                    { 1, 50f, 1, "1 cây xà lách, 1/2 trái dưa leo, 2 trái cà chua", "https://picsum.photos/200", "Rau trộn", 20000m, 1 },
                    { 2, 50f, 1, "2 cây xà lách, 1 trái dưa leo, 4 trái cà chua", "https://picsum.photos/200", "Rau trộn", 10000m, 2 },
                    { 3, 50f, 1, "1/2 kg rau muống", "https://picsum.photos/200", "Rau luộc", 20000m, 1 },
                    { 4, 50f, 1, "1 kg rau muống", "https://picsum.photos/200", "Rau luộc", 10000m, 2 },
                    { 5, 50f, 2, "trái cây", "https://picsum.photos/200", "Trái cây tô", 30000m, 1 },
                    { 6, 50f, 2, "trái cây", "https://picsum.photos/200", "Trái cây tô", 50000m, 2 },
                    { 7, 50f, 2, "trái cây", "https://picsum.photos/200", "Trái cây tô", 79000m, 3 },
                    { 8, 250f, 1, "1 bơ", "https://picsum.photos/200", "Sinh tố bơ", 25000m, 1 },
                    { 9, 250f, 1, "2 bơ", "https://picsum.photos/200", "Sinh tố bơ", 30000m, 2 },
                    { 10, 250f, 1, "3 bơ", "https://picsum.photos/200", "Sinh tố bơ", 35000m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CATE_ID",
                table: "Menus",
                column: "CATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_CODE_ID",
                table: "Order_Details",
                column: "CODE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_MENU_ID",
                table: "Order_Details",
                column: "MENU_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Order_Details");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Oders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
