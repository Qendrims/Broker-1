using Microsoft.EntityFrameworkCore.Migrations;

namespace Broker.Migrations
{
    public partial class deleteAccNr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNr",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountNr",
                table: "Users",
                type: "bigint",
                nullable: true);
        }
    }
}
