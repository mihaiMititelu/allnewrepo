using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniFIIcation.Migrations
{
    public partial class AnnouncementsFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "ReviewModels");

            migrationBuilder.CreateTable(
                "Announcements",
                table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    TextContent = table.Column<string>(maxLength: 1000, nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Announcements", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Announcements");

            migrationBuilder.CreateTable(
                "ReviewModels",
                table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(maxLength: 1000, nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_ReviewModels", x => x.Id); });
        }
    }
}