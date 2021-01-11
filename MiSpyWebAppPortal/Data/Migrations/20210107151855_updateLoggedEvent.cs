using Microsoft.EntityFrameworkCore.Migrations;

namespace MiSpyWebAppPortal.Data.Migrations
{
    public partial class updateLoggedEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasRead",
                table: "LoggedEvent",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasRead",
                table: "LoggedEvent");
        }
    }
}
