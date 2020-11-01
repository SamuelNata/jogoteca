using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jogoteca.Web.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 150, nullable: false),
                    year = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    email = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_borrowings",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    start_date = table.Column<DateTime>(nullable: false),
                    predicted_end_date = table.Column<DateTime>(nullable: false),
                    real_end_date = table.Column<DateTime>(nullable: true),
                    game_owner_id = table.Column<Guid>(nullable: false),
                    game_borrower_id = table.Column<Guid>(nullable: false),
                    borrowed_game_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_borrowings", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_borrowings_games_borrowed_game_id",
                        column: x => x.borrowed_game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_borrowings_users_game_borrower_id",
                        column: x => x.game_borrower_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_borrowings_users_game_owner_id",
                        column: x => x.game_owner_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_games",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    user_id = table.Column<Guid>(nullable: true),
                    game_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_games", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_games_games_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_games_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_borrowings_borrowed_game_id",
                table: "game_borrowings",
                column: "borrowed_game_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_borrowings_game_borrower_id",
                table: "game_borrowings",
                column: "game_borrower_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_borrowings_game_owner_id",
                table: "game_borrowings",
                column: "game_owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_games_game_id",
                table: "user_games",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_games_user_id",
                table: "user_games",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_borrowings");

            migrationBuilder.DropTable(
                name: "user_games");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
