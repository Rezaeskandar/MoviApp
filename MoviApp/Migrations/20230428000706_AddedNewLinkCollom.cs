using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewLinkCollom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewLinks",
                table: "PersonGenere",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewLink",
                table: "MovieGenres",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewLinks",
                table: "PersonGenere");

            migrationBuilder.DropColumn(
                name: "NewLink",
                table: "MovieGenres");
        }
    }
}
