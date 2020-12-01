using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Migrations
{
    public partial class UpdateDSToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MARK",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ADMIN_ID", "PASSWD", "USERNAME" },
                values: new object[] { 8, "123456!", "ducanh@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "ADMIN_ID",
                keyValue: 8);

            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "Accounts",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MARK",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }
    }
}
