using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicShop.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class singleguncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SingerName",
                table: "SingleSongs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SingerName",
                table: "SingleSongs");
        }
    }
}
