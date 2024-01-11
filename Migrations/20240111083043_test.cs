using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVProjekt1._0.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Description",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
