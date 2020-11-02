using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jogoteca.Web.Migrations
{
    public partial class OwnershipRemodeling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_game_borrowings_games_borrowed_game_id",
                table: "game_borrowings");

            migrationBuilder.DropForeignKey(
                name: "fk_game_borrowings_users_game_owner_id",
                table: "game_borrowings");

            migrationBuilder.DropIndex(
                name: "ix_game_borrowings_borrowed_game_id",
                table: "game_borrowings");

            migrationBuilder.DropIndex(
                name: "ix_game_borrowings_game_owner_id",
                table: "game_borrowings");

            migrationBuilder.DropColumn(
                name: "borrowed_game_id",
                table: "game_borrowings");

            migrationBuilder.DropColumn(
                name: "game_owner_id",
                table: "game_borrowings");

            migrationBuilder.AddColumn<Guid>(
                name: "game_ownership_id",
                table: "game_borrowings",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_game_borrowings_game_ownership_id",
                table: "game_borrowings",
                column: "game_ownership_id");

            migrationBuilder.AddForeignKey(
                name: "fk_game_borrowings_user_games_game_ownership_id",
                table: "game_borrowings",
                column: "game_ownership_id",
                principalTable: "user_games",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_game_borrowings_user_games_game_ownership_id",
                table: "game_borrowings");

            migrationBuilder.DropIndex(
                name: "ix_game_borrowings_game_ownership_id",
                table: "game_borrowings");

            migrationBuilder.DropColumn(
                name: "game_ownership_id",
                table: "game_borrowings");

            migrationBuilder.AddColumn<Guid>(
                name: "borrowed_game_id",
                table: "game_borrowings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "game_owner_id",
                table: "game_borrowings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_game_borrowings_borrowed_game_id",
                table: "game_borrowings",
                column: "borrowed_game_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_borrowings_game_owner_id",
                table: "game_borrowings",
                column: "game_owner_id");

            migrationBuilder.AddForeignKey(
                name: "fk_game_borrowings_games_borrowed_game_id",
                table: "game_borrowings",
                column: "borrowed_game_id",
                principalTable: "games",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_game_borrowings_users_game_owner_id",
                table: "game_borrowings",
                column: "game_owner_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
