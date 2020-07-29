using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Web.Migrations.Framework
{
    public partial class CampaignUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Campaigns",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Campaigns",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Smtps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmtpProvider = table.Column<string>(nullable: true),
                    SmtpHostServer = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    EnableSsl = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smtps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Smtps");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Campaigns");

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }
    }
}
