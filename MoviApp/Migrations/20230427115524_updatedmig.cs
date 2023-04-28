using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviApp.Migrations
{
    /// <inheritdoc />
    public partial class updatedmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genres_GenresGenerId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movies_MoviesMovieId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Person_personsPersonId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonGenere_Person_PersonsPersonId",
                table: "PersonGenere");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Movies_MoviesMovieId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Person_PersonsPersonId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "MovieGenre",
                newName: "MovieGenres");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_PersonsPersonId",
                table: "Ratings",
                newName: "IX_Ratings_PersonsPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_MoviesMovieId",
                table: "Ratings",
                newName: "IX_Ratings_MoviesMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenre_MoviesMovieId",
                table: "MovieGenres",
                newName: "IX_MovieGenres_MoviesMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenre_GenresGenerId",
                table: "MovieGenres",
                newName: "IX_MovieGenres_GenresGenerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "RatingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenres",
                table: "MovieGenres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Genres_GenresGenerId",
                table: "MovieGenres",
                column: "GenresGenerId",
                principalTable: "Genres",
                principalColumn: "GenerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Movies_MoviesMovieId",
                table: "MovieGenres",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Persons_personsPersonId",
                table: "Movies",
                column: "personsPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonGenere_Persons_PersonsPersonId",
                table: "PersonGenere",
                column: "PersonsPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MoviesMovieId",
                table: "Ratings",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Persons_PersonsPersonId",
                table: "Ratings",
                column: "PersonsPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Genres_GenresGenerId",
                table: "MovieGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Movies_MoviesMovieId",
                table: "MovieGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Persons_personsPersonId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonGenere_Persons_PersonsPersonId",
                table: "PersonGenere");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MoviesMovieId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Persons_PersonsPersonId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenres",
                table: "MovieGenres");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "MovieGenres",
                newName: "MovieGenre");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_PersonsPersonId",
                table: "Rating",
                newName: "IX_Rating_PersonsPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_MoviesMovieId",
                table: "Rating",
                newName: "IX_Rating_MoviesMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenres_MoviesMovieId",
                table: "MovieGenre",
                newName: "IX_MovieGenre_MoviesMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenres_GenresGenerId",
                table: "MovieGenre",
                newName: "IX_MovieGenre_GenresGenerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "RatingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Genres_GenresGenerId",
                table: "MovieGenre",
                column: "GenresGenerId",
                principalTable: "Genres",
                principalColumn: "GenerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movies_MoviesMovieId",
                table: "MovieGenre",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Person_personsPersonId",
                table: "Movies",
                column: "personsPersonId",
                principalTable: "Person",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonGenere_Person_PersonsPersonId",
                table: "PersonGenere",
                column: "PersonsPersonId",
                principalTable: "Person",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Movies_MoviesMovieId",
                table: "Rating",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Person_PersonsPersonId",
                table: "Rating",
                column: "PersonsPersonId",
                principalTable: "Person",
                principalColumn: "PersonId");
        }
    }
}
