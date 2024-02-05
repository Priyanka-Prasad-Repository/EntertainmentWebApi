using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntertainmentWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingTablesSchemaAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActGender = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MovYear = table.Column<int>(type: "int", nullable: false),
                    MovLang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MovReleaseCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MovRelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    actorId = table.Column<int>(type: "int", nullable: false),
                    directorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovId);
                    table.ForeignKey(
                        name: "FK_Movies_Actors_actorId",
                        column: x => x.actorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_directorId",
                        column: x => x.directorId,
                        principalTable: "Directors",
                        principalColumn: "DirId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "ActGender", "ActName" },
                values: new object[,]
                {
                    { 1, "M", "Ranbir Kapoor" },
                    { 2, "F", "Alia Bhatt" },
                    { 3, "F", "Priyanka Chopra" },
                    { 4, "M", "Amitabh Bacchan" },
                    { 5, "M", "Ajay Devagan" },
                    { 6, "M", "Arshad Warsi" },
                    { 7, "M", "Sharukh Khan" },
                    { 8, "F", "Pooja Bhatt" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "DirId", "DirName" },
                values: new object[,]
                {
                    { 101, "Alia Bhatt" },
                    { 102, "Rohit Shetty" },
                    { 103, "Pooja Bhatt" },
                    { 104, "Sharukh Khan" },
                    { 105, "NTR" },
                    { 106, "Karan Johar" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreTitle" },
                values: new object[,]
                {
                    { 1001, "Horror" },
                    { 1002, "Sci-Fiction" },
                    { 1003, "Comedy" },
                    { 1004, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovId", "GenreId", "MovLang", "MovRelDate", "MovReleaseCountry", "MovTitle", "MovYear", "actorId", "directorId" },
                values: new object[,]
                {
                    { 801, 1002, "PAN India", new DateTime(2024, 2, 5, 15, 31, 0, 917, DateTimeKind.Local).AddTicks(2813), "Worldwide", "Brahmastra", 2024, 2, 101 },
                    { 802, 1003, "PAN India", new DateTime(2024, 2, 5, 15, 31, 0, 917, DateTimeKind.Local).AddTicks(2825), "Worldwide", "RRR", 2024, 5, 103 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "MovieId", "ReviewText", "ReviewTitle" },
                values: new object[,]
                {
                    { 201, 801, "Rotten tomatotes", "1 star" },
                    { 202, 801, "Very Bad movie", "1 star" },
                    { 203, 801, "Fantastic movie", "4 star" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_actorId",
                table: "Movies",
                column: "actorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_directorId",
                table: "Movies",
                column: "directorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
