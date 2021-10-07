using Microsoft.EntityFrameworkCore.Migrations;

namespace mlmanagment1.Data.Migrations
{
    public partial class CONTROL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_OffertTypes_OffertTypeId1",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_OffertTypeId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OffertTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OffertTypeId1",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "OffertTypeId",
                table: "Customers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "OffertTypeId1",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OffertTypeId1",
                table: "Customers",
                column: "OffertTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_OffertTypes_OffertTypeId1",
                table: "Customers",
                column: "OffertTypeId1",
                principalTable: "OffertTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
