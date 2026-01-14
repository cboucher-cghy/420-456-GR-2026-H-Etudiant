using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Identity.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUserToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "AspNetUsers");
        }
    }
}
