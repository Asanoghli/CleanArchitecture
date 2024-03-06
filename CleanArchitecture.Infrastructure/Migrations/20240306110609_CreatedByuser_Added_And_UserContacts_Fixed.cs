using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByuser_Added_And_UserContacts_Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Page_ParentId",
                table: "Page");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContacts_Users_UserId",
                table: "UserContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Page",
                table: "Page");

            migrationBuilder.RenameTable(
                name: "Page",
                newName: "Pages");

            migrationBuilder.RenameIndex(
                name: "IX_Page_ParentId",
                table: "Pages",
                newName: "IX_Pages_ParentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 6, 11, 6, 9, 250, DateTimeKind.Utc).AddTicks(4247),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 3, 15, 45, 23, 519, DateTimeKind.Utc).AddTicks(7201));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "UserContacts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "UserContacts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "UserContacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "UserContacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "UserContacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Pages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "Pages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "Pages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "Pages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "Pages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pages",
                table: "Pages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePathEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slides_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slides_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Slides_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_CreatedByUserId",
                table: "UserContacts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_DeletedByUserId",
                table: "UserContacts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_UpdatedByUserId",
                table: "UserContacts",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_CreatedByUserId",
                table: "Pages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_DeletedByUserId",
                table: "Pages",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_UpdatedByUserId",
                table: "Pages",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_CreatedByUserId",
                table: "Slides",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_DeletedByUserId",
                table: "Slides",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_UpdatedByUserId",
                table: "Slides",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Pages_ParentId",
                table: "Pages",
                column: "ParentId",
                principalTable: "Pages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Users_CreatedByUserId",
                table: "Pages",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Users_DeletedByUserId",
                table: "Pages",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Users_UpdatedByUserId",
                table: "Pages",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContacts_Users_CreatedByUserId",
                table: "UserContacts",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserContacts_Users_DeletedByUserId",
                table: "UserContacts",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContacts_Users_UpdatedByUserId",
                table: "UserContacts",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContacts_Users_UserId",
                table: "UserContacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Pages_ParentId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Users_CreatedByUserId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Users_DeletedByUserId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Users_UpdatedByUserId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContacts_Users_CreatedByUserId",
                table: "UserContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContacts_Users_DeletedByUserId",
                table: "UserContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContacts_Users_UpdatedByUserId",
                table: "UserContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContacts_Users_UserId",
                table: "UserContacts");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropIndex(
                name: "IX_UserContacts_CreatedByUserId",
                table: "UserContacts");

            migrationBuilder.DropIndex(
                name: "IX_UserContacts_DeletedByUserId",
                table: "UserContacts");

            migrationBuilder.DropIndex(
                name: "IX_UserContacts_UpdatedByUserId",
                table: "UserContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pages",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_CreatedByUserId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_DeletedByUserId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_UpdatedByUserId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UserContacts");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "UserContacts");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "UserContacts");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "UserContacts");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "UserContacts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Pages");

            migrationBuilder.RenameTable(
                name: "Pages",
                newName: "Page");

            migrationBuilder.RenameIndex(
                name: "IX_Pages_ParentId",
                table: "Page",
                newName: "IX_Page_ParentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 3, 15, 45, 23, 519, DateTimeKind.Utc).AddTicks(7201),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 6, 11, 6, 9, 250, DateTimeKind.Utc).AddTicks(4247));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Page",
                table: "Page",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Page_ParentId",
                table: "Page",
                column: "ParentId",
                principalTable: "Page",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContacts_Users_UserId",
                table: "UserContacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
