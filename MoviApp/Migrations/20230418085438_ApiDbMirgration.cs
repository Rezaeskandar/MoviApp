using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviApp.Migrations
{
    /// <inheritdoc />
    public partial class ApiDbMirgration : Migration
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
                    Movelink = table.Column<string>(type: "varchar(255)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenerId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "The most sold film and emotianl int not recomends for pepole under 14.", "Legal drama" },
                    { 2, "The most sold film and emotianl int not recomends for pepole under 20.", "drama" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Movelink", "Rating", "personGenereId" },
                values: new object[,]
                {
                    { 1, "https://www.themoviedb.org/movie/19973-comedian", 5, null },
                    { 2, "https://www.themoviedb.org/movie/79168-drama", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Rezaeskand@gmail.com", "reza" },
                    { 2, "Rasouleskand@gmail.com", "Rasoul" }
                });

            migrationBuilder.InsertData(
                table: "PersonGenere",
                columns: new[] { "personGenereId", "GenerId", "PersonId" },
                values: new object[,]
                {
                    { 1, null, null },
                    { 2, null, null }
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
