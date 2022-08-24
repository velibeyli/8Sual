using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _8Sual.Migrations
{
    public partial class edit_question : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Category_CategoryId",
                table: "Question");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Category_CategoryId",
                table: "Question",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Category_CategoryId",
                table: "Question");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Question",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Category_CategoryId",
                table: "Question",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
