using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVProjekt1._0.Migrations
{
    /// <inheritdoc />
    public partial class LaTillYtterligareEnPropertyIUserMigreraFörFan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPrivate",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPrivate",
                table: "AspNetUsers");
        }
    }
}
