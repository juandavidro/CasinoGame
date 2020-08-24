using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CasinoGame.DataAccess.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Roulettes",
                table: "Roulettes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Roulettes");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Credit",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LoginDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "RouletteId",
                table: "Roulettes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CloseDate",
                table: "Roulettes",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "Roulettes",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "OpenDate",
                table: "Roulettes",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roulettes",
                table: "Roulettes",
                column: "RouletteId");

            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    BetId = table.Column<Guid>(nullable: false),
                    BetNumber = table.Column<int>(nullable: false),
                    BetColor = table.Column<string>(nullable: true),
                    BetValue = table.Column<int>(nullable: false),
                    RouletteId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BetDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.BetId);
                    table.ForeignKey(
                        name: "FK_Bet_Roulettes_RouletteId",
                        column: x => x.RouletteId,
                        principalTable: "Roulettes",
                        principalColumn: "RouletteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bet_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bet_RouletteId",
                table: "Bet",
                column: "RouletteId");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_UserId",
                table: "Bet",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roulettes",
                table: "Roulettes");

            migrationBuilder.DropColumn(
                name: "Credit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LoginDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RouletteId",
                table: "Roulettes");

            migrationBuilder.DropColumn(
                name: "CloseDate",
                table: "Roulettes");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Roulettes");

            migrationBuilder.DropColumn(
                name: "OpenDate",
                table: "Roulettes");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Roulettes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roulettes",
                table: "Roulettes",
                column: "Id");
        }
    }
}
