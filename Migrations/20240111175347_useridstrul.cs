using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVProjekt1._0.Migrations
{
    /// <inheritdoc />
    public partial class useridstrul : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ProjectUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectUsers");
        }
    }
}
