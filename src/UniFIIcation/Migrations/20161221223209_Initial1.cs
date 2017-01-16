using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniFIIcation.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "UId",
                "AspNetUsers");

            migrationBuilder.RenameColumn(
                "Parola",
                "AspNetUsers",
                "Password");

            migrationBuilder.AddColumn<int>(
                "An",
                "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "An",
                "AspNetUsers");

            migrationBuilder.RenameColumn(
                "Password",
                "AspNetUsers",
                "Parola");

            migrationBuilder.AddColumn<Guid>(
                "UId",
                "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}