using Microsoft.EntityFrameworkCore.Migrations;

namespace GameServerAPI.Migrations
{
    public partial class InitialMigrationScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameServerItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(nullable: true),
                    Playstation4 = table.Column<string>(nullable: true),
                    XboxOne = table.Column<string>(nullable: true),
                    Switch = table.Column<string>(nullable: true),
                    PC = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameServerItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameServerItem");
        }
    }
}
