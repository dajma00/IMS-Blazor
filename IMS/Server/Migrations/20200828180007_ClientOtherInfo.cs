using Microsoft.EntityFrameworkCore.Migrations;

namespace IMS.Server.Migrations
{
    public partial class ClientOtherInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "tblQuotes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "tblQuotes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "tblQuotes");

            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "tblQuotes");
        }
    }
}
