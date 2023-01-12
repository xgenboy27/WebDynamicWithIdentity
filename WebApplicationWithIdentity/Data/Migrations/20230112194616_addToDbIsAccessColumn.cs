using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationWithIdentity.Data.Migrations
{
    public partial class addToDbIsAccessColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuMaster",
                columns: table => new
                {
                    MenuIdentity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parent_MenuID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Roll = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USE_YN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAccess = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMaster", x => x.MenuIdentity);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuMaster");
        }
    }
}
