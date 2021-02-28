using Microsoft.EntityFrameworkCore.Migrations;

namespace starting_with_aspnetcore.Migrations
{
    public partial class addemailrepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Repository",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Repository");
        }
    }
}
