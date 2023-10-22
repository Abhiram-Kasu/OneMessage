using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneMessage.Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreatedFriendshipsForReal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "friend_ships",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    from_user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    to_user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_friend_ships", x => x.id);
                    table.ForeignKey(
                        name: "fk_friend_ships_users_from_user_id",
                        column: x => x.from_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_friend_ships_users_to_user_id",
                        column: x => x.to_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_friend_ships_from_user_id",
                table: "friend_ships",
                column: "from_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_friend_ships_to_user_id",
                table: "friend_ships",
                column: "to_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "friend_ships");
        }
    }
}
