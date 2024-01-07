using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVProjekt1._0.Migrations
{
    /// <inheritdoc />
    public partial class desiredParticipants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesiredManpower",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesiredManpower",
                table: "Projects");
        }
    }
}
