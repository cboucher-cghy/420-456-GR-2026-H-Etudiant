using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeniusChuck.Newsletter.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()", comment: "Indique la date/heure de son inscription")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategorySubscriber",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubscriberId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()", comment: "Indique la date/heure de son inscription pour une catégorie donnée!")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySubscriber", x => new { x.CategoryId, x.SubscriberId });
                    table.ForeignKey(
                        name: "FK_CategorySubscriber_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySubscriber_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 28, 13, 22, 57, 251, DateTimeKind.Local).AddTicks(4753), "Vive le sport.", "Sport" },
                    { 2, new DateTime(2026, 1, 28, 13, 22, 57, 253, DateTimeKind.Local).AddTicks(3034), "Vive la culture.", "Culture" },
                    { 3, new DateTime(2026, 1, 28, 13, 22, 57, 253, DateTimeKind.Local).AddTicks(3051), "Vive la politique.", "Politique" },
                    { 5, new DateTime(2026, 1, 28, 13, 22, 57, 253, DateTimeKind.Local).AddTicks(3054), "Vive les jeux vidéo.", "Jeux vidéo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorySubscriber_SubscriberId",
                table: "CategorySubscriber",
                column: "SubscriberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySubscriber");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Subscribers");
        }
    }
}
