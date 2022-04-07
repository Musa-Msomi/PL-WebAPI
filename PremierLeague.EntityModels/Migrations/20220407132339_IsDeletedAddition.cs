using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeague.EntityModels.Migrations
{
    public partial class IsDeletedAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Players");
        }
    }
}
