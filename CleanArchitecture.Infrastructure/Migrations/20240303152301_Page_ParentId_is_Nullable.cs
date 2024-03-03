using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Page_ParentId_is_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 3, 15, 23, 0, 873, DateTimeKind.Utc).AddTicks(420),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 3, 15, 16, 39, 271, DateTimeKind.Utc).AddTicks(5467));

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentId",
                table: "Page",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 3, 15, 16, 39, 271, DateTimeKind.Utc).AddTicks(5467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 3, 15, 23, 0, 873, DateTimeKind.Utc).AddTicks(420));

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentId",
                table: "Page",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
