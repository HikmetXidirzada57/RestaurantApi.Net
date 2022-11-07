using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Orderstatuschanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "OrderInfos",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "TableName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WaiterName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WaiterName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "OrderInfos",
                newName: "OrderStatus");
        }
    }
}
