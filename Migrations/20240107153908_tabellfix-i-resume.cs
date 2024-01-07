using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVProjekt1._0.Migrations
{
    /// <inheritdoc />
    public partial class tabellfixiresume : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_AspNetUsers_UserId",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_UserId",
                table: "Resumes");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Resumes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_UserId",
                table: "Resumes",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_AspNetUsers_UserId",
                table: "Resumes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_AspNetUsers_UserId",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_UserId",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "Resumes");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Resumes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_UserId",
                table: "Resumes",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_AspNetUsers_UserId",
                table: "Resumes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
