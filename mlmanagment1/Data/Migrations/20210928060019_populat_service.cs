using Microsoft.EntityFrameworkCore.Migrations;

namespace mlmanagment1.Data.Migrations
{
    public partial class populat_service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO OffertTypes( ServiceOfered , Pricing) VALUES ( 'Tax Preparation' , 120)");
            migrationBuilder.Sql("INSERT INTO OffertTypes(ServiceOfered , Pricing) VALUES ( 'Immigration' , 500)");
            migrationBuilder.Sql("INSERT INTO OffertTypes(ServiceOfered , Pricing) VALUES ( 'Printing' , 0 )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
