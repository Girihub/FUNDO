using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotesType",
                table: "Notes");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "Notes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNote",
                table: "Notes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrash",
                table: "Notes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IsNote",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IsTrash",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "NotesType",
                table: "Notes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
