using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviApp.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
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
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Movelink = table.Column<string>(type: "varchar(255)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    GenersGenerId = table.Column<int>(type: "int", nullable: true),
                    personsPersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenersGenerId",
                        column: x => x.GenersGenerId,
                        principalTable: "Genres",
                        principalColumn: "GenerId");
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
                    personGenereId = table.Column<int>(type: "int", nullable: false),
                    FK_personId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGenere", x => x.personGenereId);
                    table.ForeignKey(
                        name: "FK_PersonGenere_Genres_personGenereId",
                        column: x => x.personGenereId,
                        principalTable: "Genres",
                        principalColumn: "GenerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonGenere_Person_personGenereId",
                        column: x => x.personGenereId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenersGenerId",
                table: "Movies",
                column: "GenersGenerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_personsPersonId",
                table: "Movies",
                column: "personsPersonId");
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
