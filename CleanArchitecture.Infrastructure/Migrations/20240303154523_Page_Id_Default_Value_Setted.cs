using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Page_Id_Default_Value_Setted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 3, 15, 45, 23, 519, DateTimeKind.Utc).AddTicks(7201),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 3, 15, 25, 34, 533, DateTimeKind.Utc).AddTicks(6814));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 3, 15, 25, 34, 533, DateTimeKind.Utc).AddTicks(6814),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 3, 15, 45, 23, 519, DateTimeKind.Utc).AddTicks(7201));
        }
    }
}
