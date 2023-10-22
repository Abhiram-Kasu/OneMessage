using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneMessage.Application.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedPrimaryKeyToFriendships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_friend_ships_id",
                table: "friend_ships",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_friend_ships_id",
                table: "friend_ships");
        }
    }
}
