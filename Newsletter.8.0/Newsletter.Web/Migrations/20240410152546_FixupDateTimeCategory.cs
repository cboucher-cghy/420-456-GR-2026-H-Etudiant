using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeniusChuck.Newsletter.Web.Migrations
{
    /// <inheritdoc />
    public partial class FixupDateTimeCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Subscribers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Subscribers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                comment: "Indique la date/heure de son inscription",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Indique la date/heure de son inscription");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionDate",
                table: "CategorySubscriber",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                comment: "Indique la date/heure de son inscription pour une catégorie donnée!",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Indique la date/heure de son inscription pour une catégorie donnée!");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: DateTime.Now);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 25, 45, 781, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 25, 45, 781, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 25, 45, 781, DateTimeKind.Local).AddTicks(2131));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Subscribers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Indique la date/heure de son inscription",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()",
                oldComment: "Indique la date/heure de son inscription");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Subscribers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionDate",
                table: "CategorySubscriber",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Indique la date/heure de son inscription pour une catégorie donnée!",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()",
                oldComment: "Indique la date/heure de son inscription pour une catégorie donnée!");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
