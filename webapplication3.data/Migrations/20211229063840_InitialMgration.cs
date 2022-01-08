using Microsoft.EntityFrameworkCore.Migrations;

namespace webapplication3.Data.Migrations
{
    public partial class InitialMgration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 80, nullable: false),
                    location = table.Column<string>(maxLength: 255, nullable: false),
                    Cuisine = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.id);
                });

           // migrationBuilder.Sql("INSERT INTO RESTAURANT (name,location,Cuisine) values ('scots','maryland','none') ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
