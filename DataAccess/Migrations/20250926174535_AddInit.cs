using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PosterUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sci-Fi" },
                    { 2, "Drama" },
                    { 3, "Adventure" },
                    { 4, "Action" },
                    { 5, "Romance" },
                    { 6, "Crime" },
                    { 7, "Animation" },
                    { 8, "Mystery" },
                    { 9, "Biography" },
                    { 10, "Musical" },
                    { 11, "Thriller" },
                    { 12, "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Favorite", "GenreId", "PosterUrl", "Rating", "StartTime", "Title", "TrailerUrl", "Year" },
                values: new object[,]
                {
                    { 1, "Explorers travel through a wormhole in space to save humanity.", false, 1, "https://m.media-amazon.com/images/M/MV5BYzdjMDAxZGItMjI2My00ODA1LTlkNzItOWFjMDU5ZDJlYWY3XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg", 4, new DateTime(2025, 8, 22, 14, 30, 0, 0, DateTimeKind.Unspecified), "Interstellar", "https://www.youtube.com/watch?v=zSWdZVtXT7E", 2013 },
                    { 2, "Batman faces the Joker, a criminal mastermind.", false, 4, "https://cdn.europosters.eu/image/1300/197743.jpg", 5, new DateTime(2025, 8, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight", "https://www.youtube.com/watch?v=EXeTwQWrcwY", 2009 },
                    { 3, "A slow-witted man witnesses and influences historical events.", false, 2, "https://m.media-amazon.com/images/M/MV5BNDYwNzVjMTItZmU5YS00YjQ5LTljYjgtMjY2NDVmYWMyNWFmXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg", 4, new DateTime(2025, 8, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump", "https://www.youtube.com/watch?v=bLvqoHBptjg", 1994 },
                    { 4, "A computer hacker learns the true nature of reality.", false, 1, "https://m.media-amazon.com/images/I/51ISve-1n1S._UF1000,1000_QL80_.jpg", 4, new DateTime(2025, 8, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix", "https://www.youtube.com/watch?v=vKQi3bBA1y8", 1999 },
                    { 5, "The lives of two mob hitmen, a boxer, and others intertwine.", false, 6, "https://cdn.europosters.eu/image/750/1288.jpg", 4, new DateTime(2025, 8, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction", "https://www.youtube.com/watch?v=s7EdQ4FqbhY", 1994 },
                    { 6, "A former Roman General sets out to exact vengeance.", false, 4, "https://m.media-amazon.com/images/I/71sj8Yt20qL.jpg", 4, new DateTime(2025, 8, 24, 19, 30, 0, 0, DateTimeKind.Unspecified), "Gladiator", "https://www.youtube.com/watch?v=owK1qxDselE", 2000 },
                    { 7, "A romance blooms aboard the ill-fated RMS Titanic.", false, 5, "https://m.media-amazon.com/images/I/71ZJ8am0mKL._UF894,1000_QL80_.jpg", 3, new DateTime(2025, 8, 23, 14, 0, 0, 0, DateTimeKind.Unspecified), "Titanic", "https://www.youtube.com/watch?v=2e-eXJ6HgkQ", 1997 },
                    { 8, "A paraplegic Marine is dispatched to Pandora.", false, 1, "https://storage.googleapis.com/pod_public/750/262963.jpg", 3, new DateTime(2025, 8, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), "Avatar", "https://www.youtube.com/watch?v=5PSNL1qE6VY", 2009 },
                    { 9, "The aging patriarch of an organized crime dynasty transfers control to his son.", false, 6, "https://m.media-amazon.com/images/M/MV5BNGEwYjgwOGQtYjg5ZS00Njc1LTk2ZGEtM2QwZWQ2NjdhZTE5XkEyXkFqcGc@._V1_.jpg", 4, new DateTime(2025, 8, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather", "https://www.youtube.com/watch?v=sY1S34973zA", 1972 },
                    { 10, "An insomniac office worker forms an underground fight club.", false, 2, "https://m.media-amazon.com/images/M/MV5BOTgyOGQ1NDItNGU3Ny00MjU3LTg2YWEtNmEyYjBiMjI1Y2M5XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg", 4, new DateTime(2025, 8, 26, 16, 30, 0, 0, DateTimeKind.Unspecified), "Fight Club", "https://www.youtube.com/watch?v=SUXWAEX2jlg", 1999 },
                    { 11, "A young lion prince flees his kingdom only to learn the meaning of responsibility.", false, 7, "https://cdn.europosters.eu/image/1300/76297.jpg", 4, new DateTime(2025, 8, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), "The Lion King", "https://www.youtube.com/watch?v=4sj1MT05lAA", 1994 },
                    { 12, "A promising young drummer enrolls at a cut-throat music conservatory.", false, 2, "https://upload.wikimedia.org/wikipedia/uk/archive/0/01/20160208075323%21Whiplash_poster.jpg", 4, new DateTime(2025, 8, 27, 15, 30, 0, 0, DateTimeKind.Unspecified), "Whiplash", "https://www.youtube.com/watch?v=7d_jQycdQGo", 2014 },
                    { 13, "Two magicians engage in a bitter rivalry.", false, 8, "https://m.media-amazon.com/images/M/MV5BMTM3MzQ5MjQ5OF5BMl5BanBnXkFtZTcwMTQ3NzMzMw@@._V1_.jpg", 4, new DateTime(2025, 8, 27, 18, 0, 0, 0, DateTimeKind.Unspecified), "The Prestige", "https://www.youtube.com/watch?v=o4gHCmTQDVI", 2006 },
                    { 14, "The story of Facebook’s creation and its legal battles.", false, 9, "https://m.media-amazon.com/images/M/MV5BMjlkNTE5ZTUtNGEwNy00MGVhLThmZjMtZjU1NDE5Zjk1NDZkXkEyXkFqcGc@._V1_.jpg", 3, new DateTime(2025, 8, 28, 14, 30, 0, 0, DateTimeKind.Unspecified), "The Social Network", "https://www.youtube.com/watch?v=lB95KLmpLR4", 2010 },
                    { 15, "A concierge at a famous hotel gets involved in a theft and murder mystery.", false, 12, "https://storage.googleapis.com/pod_public/1300/266322.jpg", 4, new DateTime(2025, 8, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), "The Grand Budapest Hotel", "https://www.youtube.com/watch?v=1Fg5iWmQjwk", 2014 },
                    { 16, "In a post-apocalyptic wasteland, Furiosa rebels against a tyrant.", false, 4, "https://m.media-amazon.com/images/M/MV5BZDRkODJhOTgtOTc1OC00NTgzLTk4NjItNDgxZDY4YjlmNDY2XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg", 4, new DateTime(2025, 8, 29, 15, 30, 0, 0, DateTimeKind.Unspecified), "Mad Max: Fury Road", "https://www.youtube.com/watch?v=hEJnMQG9ev8", 2015 },
                    { 17, "Greed and class discrimination threaten a symbiotic relationship.", false, 11, "https://m.media-amazon.com/images/M/MV5BYjk1Y2U4MjQtY2ZiNS00OWQyLWI3MmYtZWUwNmRjYWRiNWNhXkEyXkFqcGc@._V1_.jpg", 4, new DateTime(2025, 8, 29, 18, 0, 0, 0, DateTimeKind.Unspecified), "Parasite", "https://www.youtube.com/watch?v=5xH0HfJHsaY", 2019 },
                    { 18, "A mentally troubled man embarks on a downward spiral of revolution.", false, 6, "https://m.media-amazon.com/images/M/MV5BNzY3OWQ5NDktNWQ2OC00ZjdlLThkMmItMDhhNDk3NTFiZGU4XkEyXkFqcGc@._V1_.jpg", 4, new DateTime(2025, 8, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), "Joker", "https://www.youtube.com/watch?v=zAGVQLHvwOY", 2019 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
