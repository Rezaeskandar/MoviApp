using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviApp.Migrations
{
    /// <inheritdoc />
    public partial class ApiDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenerId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "PersonGenere",
                columns: table => new
                {
                    personGenereId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    GenerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGenere", x => x.personGenereId);
                    table.ForeignKey(
                        name: "FK_PersonGenere_Genres_GenerId",
                        column: x => x.GenerId,
                        principalTable: "Genres",
                        principalColumn: "GenerId");
                    table.ForeignKey(
                        name: "FK_PersonGenere_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personGenereId = table.Column<int>(type: "int", nullable: true),
                    Movelink = table.Column<string>(type: "varchar", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_PersonGenere_personGenereId",
                        column: x => x.personGenereId,
                        principalTable: "PersonGenere",
                        principalColumn: "personGenereId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_personGenereId",
                table: "Movies",
                column: "personGenereId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGenere_GenerId",
                table: "PersonGenere",
                column: "GenerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGenere_PersonId",
                table: "PersonGenere",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "PersonGenere");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
