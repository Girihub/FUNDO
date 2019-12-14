using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Collaborate",
                newName: "CollaboratedWith");

            migrationBuilder.RenameColumn(
                name: "CollaboratorId",
                table: "Collaborate",
                newName: "CollaboratedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CollaboratedWith",
                table: "Collaborate",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "CollaboratedBy",
                table: "Collaborate",
                newName: "CollaboratorId");
        }
    }
}
