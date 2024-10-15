using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicShop.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class MusicShowUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SingleBeats_SingleSongss_SingleSongId",
                table: "SingleBeats");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleSongss_Singers_SingerId",
                table: "SingleSongss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SingleSongss",
                table: "SingleSongss");

            migrationBuilder.RenameTable(
                name: "SingleSongss",
                newName: "SingleSongs");

            migrationBuilder.RenameIndex(
                name: "IX_SingleSongss_SingerId",
                table: "SingleSongs",
                newName: "IX_SingleSongs_SingerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SingleSongs",
                table: "SingleSongs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SingleBeats_SingleSongs_SingleSongId",
                table: "SingleBeats",
                column: "SingleSongId",
                principalTable: "SingleSongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleSongs_Singers_SingerId",
                table: "SingleSongs",
                column: "SingerId",
                principalTable: "Singers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SingleBeats_SingleSongs_SingleSongId",
                table: "SingleBeats");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleSongs_Singers_SingerId",
                table: "SingleSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SingleSongs",
                table: "SingleSongs");

            migrationBuilder.RenameTable(
                name: "SingleSongs",
                newName: "SingleSongss");

            migrationBuilder.RenameIndex(
                name: "IX_SingleSongs_SingerId",
                table: "SingleSongss",
                newName: "IX_SingleSongss_SingerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SingleSongss",
                table: "SingleSongss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SingleBeats_SingleSongss_SingleSongId",
                table: "SingleBeats",
                column: "SingleSongId",
                principalTable: "SingleSongss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleSongss_Singers_SingerId",
                table: "SingleSongss",
                column: "SingerId",
                principalTable: "Singers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
