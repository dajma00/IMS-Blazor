using Microsoft.EntityFrameworkCore.Migrations;

namespace IMS.Server.Migrations
{
    public partial class clientname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "tblQuotes",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "tblQuotes");
        }
    }
}
