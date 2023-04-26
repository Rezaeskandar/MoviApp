using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviApp.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
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
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Movelink = table.Column<string>(type: "varchar(255)", nullable: false),
                    FkPersonId = table.Column<int>(type: "int", nullable: false),
                    personsPersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Person_personsPersonId",
                        column: x => x.personsPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "PersonGenere",
                columns: table => new
                {
                    personGenereId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_personId = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: true),
                    FK_GenreId = table.Column<int>(type: "int", nullable: false),
                    GenresGenerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGenere", x => x.personGenereId);
                    table.ForeignKey(
                        name: "FK_PersonGenere_Genres_GenresGenerId",
                        column: x => x.GenresGenerId,
                        principalTable: "Genres",
                        principalColumn: "GenerId");
                    table.ForeignKey(
                        name: "FK_PersonGenere_Person_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkGenreId = table.Column<int>(type: "int", nullable: false),
                    GenresGenerId = table.Column<int>(type: "int", nullable: true),
                    FkMovieId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genres_GenresGenerId",
                        column: x => x.GenresGenerId,
                        principalTable: "Genres",
                        principalColumn: "GenerId");
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId");
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ratings = table.Column<int>(type: "int", nullable: true),
                    Fk_PersonId = table.Column<int>(type: "int", nullable: true),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: true),
                    FkMovieId = table.Column<int>(type: "int", nullable: true),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Rating_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId");
                    table.ForeignKey(
                        name: "FK_Rating_Person_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenresGenerId",
                table: "MovieGenre",
                column: "GenresGenerId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MoviesMovieId",
                table: "MovieGenre",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_personsPersonId",
                table: "Movies",
                column: "personsPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGenere_GenresGenerId",
                table: "PersonGenere",
                column: "GenresGenerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGenere_PersonsPersonId",
                table: "PersonGenere",
                column: "PersonsPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_MoviesMovieId",
                table: "Rating",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_PersonsPersonId",
                table: "Rating",
                column: "PersonsPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "PersonGenere");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
