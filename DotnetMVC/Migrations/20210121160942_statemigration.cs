using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetMVC.Migrations
{
    public partial class statemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    stid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    st_title = table.Column<string>(maxLength: 200, nullable: false),
                    st_created_date = table.Column<DateTime>(nullable: false),
                    st_country = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.stid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    genderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gn_created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gendertitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.genderid);
                });
        }
    }
}
