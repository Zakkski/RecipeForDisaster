using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeForDisaster.Migrations
{
    public partial class MakeCreatorIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Users_CreatorId",
                table: "Lists");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Lists",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Users_CreatorId",
                table: "Lists",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Users_CreatorId",
                table: "Lists");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Lists",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Users_CreatorId",
                table: "Lists",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
