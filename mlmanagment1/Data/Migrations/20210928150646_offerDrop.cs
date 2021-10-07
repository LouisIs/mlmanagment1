using Microsoft.EntityFrameworkCore.Migrations;

namespace mlmanagment1.Data.Migrations
{
    public partial class offerDrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OffertTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OffertTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pricing = table.Column<int>(type: "int", nullable: false),
                    ServiceOfered = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffertTypes", x => x.Id);
                });
        }
    }
}
