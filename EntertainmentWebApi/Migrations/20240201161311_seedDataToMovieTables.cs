using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntertainmentWebApi.Migrations
{
    /// <inheritdoc />
    public partial class seedDataToMovieTables : Migration
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
                    act_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    act_gender = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    dir_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dir_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.dir_id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre_title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    mov_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mov_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    mov_year = table.Column<int>(type: "int", nullable: false),
                    mov_lang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mov_release_country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mov_rel_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    actor_id = table.Column<int>(type: "int", nullable: false),
                    director_id = table.Column<int>(type: "int", nullable: false),
                    genre_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.mov_id);
                    table.ForeignKey(
                        name: "FK_Movies_Actors_actor_id",
                        column: x => x.actor_id,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_director_id",
                        column: x => x.director_id,
                        principalTable: "Directors",
                        principalColumn: "dir_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "Genres",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    reviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    review_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    review_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    movieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.reviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_movieId",
                        column: x => x.movieId,
                        principalTable: "Movies",
                        principalColumn: "mov_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "act_gender", "act_name" },
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
                columns: new[] { "dir_id", "dir_name" },
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
                columns: new[] { "genre_id", "genre_title" },
                values: new object[,]
                {
                    { 1001, "Horror" },
                    { 1002, "Sci-Fiction" },
                    { 1003, "Comedy" },
                    { 1004, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "mov_id", "actor_id", "director_id", "genre_id", "mov_lang", "mov_rel_date", "mov_release_country", "mov_title", "mov_year" },
                values: new object[,]
                {
                    { 801, 2, 101, 1002, "PAN India", new DateTime(2024, 2, 1, 21, 43, 10, 971, DateTimeKind.Local).AddTicks(1047), "Worldwide", "Brahmastra", 2024 },
                    { 802, 5, 103, 1003, "PAN India", new DateTime(2024, 2, 1, 21, 43, 10, 971, DateTimeKind.Local).AddTicks(1059), "Worldwide", "RRR", 2024 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "reviewId", "movieId", "review_Text", "review_Title" },
                values: new object[,]
                {
                    { 201, 801, "Rotten tomatotes", "1 star" },
                    { 202, 801, "Very Bad movie", "1 star" },
                    { 203, 801, "Fantastic movie", "4 star" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_actor_id",
                table: "Movies",
                column: "actor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_director_id",
                table: "Movies",
                column: "director_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_genre_id",
                table: "Movies",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_movieId",
                table: "Reviews",
                column: "movieId");
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
