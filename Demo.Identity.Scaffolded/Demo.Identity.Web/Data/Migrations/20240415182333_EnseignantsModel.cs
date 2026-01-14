using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Identity.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class EnseignantsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateEmbauche",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEmbauche",
                table: "AspNetUsers");
        }
    }
}
