using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public static class DbInitializer
    {
        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new List<Genre>()
            {
                new() { Id = 1, Name = "Sci-Fi" },
                new() { Id = 2, Name = "Drama" },
                new() { Id = 3, Name = "Adventure" },
                new() { Id = 4, Name = "Action" },
                new() { Id = 5, Name = "Romance" },
                new() { Id = 6, Name = "Crime" },
                new() { Id = 7, Name = "Animation" },
                new() { Id = 8, Name = "Mystery" },
                new() { Id = 9, Name = "Biography" },
                new() { Id = 10, Name = "Musical" },
                new() { Id = 11, Name = "Thriller" },
                new() { Id = 12, Name = "Comedy" }
            });
        }

        public static void SeedMovies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(new List<Movie>()
    {
        new()
        {
            Id = 1,
            Title = "Interstellar",
            Year = 2013,
            PosterUrl = "https://m.media-amazon.com/images/M/MV5BYzdjMDAxZGItMjI2My00ODA1LTlkNzItOWFjMDU5ZDJlYWY3XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
            GenreId = 1, // Sci-Fi
            Rating = 4,
            Description = "Explorers travel through a wormhole in space to save humanity.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=zSWdZVtXT7E",
            StartTime = new DateTime(2025, 8, 22, 14, 30, 0)
        },
        new()
        {
            Id = 2,
            Title = "The Dark Knight",
            Year = 2009,
            PosterUrl = "https://cdn.europosters.eu/image/1300/197743.jpg",
            GenreId = 4, // Action
            Rating = 5,
            Description = "Batman faces the Joker, a criminal mastermind.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=EXeTwQWrcwY",
            StartTime = new DateTime(2025, 8, 22, 16, 0, 0)
        },
        new()
        {
            Id = 3,
            Title = "Forrest Gump",
            Year = 1994,
            PosterUrl = "https://m.media-amazon.com/images/M/MV5BNDYwNzVjMTItZmU5YS00YjQ5LTljYjgtMjY2NDVmYWMyNWFmXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
            GenreId = 2, // Drama
            Rating = 4,
            Description = "A slow-witted man witnesses and influences historical events.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=bLvqoHBptjg",
            StartTime = new DateTime(2025, 8, 22, 13, 0, 0)
        },
        new()
        {
            Id = 4,
            Title = "The Matrix",
            Year = 1999,
            PosterUrl = "https://m.media-amazon.com/images/I/51ISve-1n1S._UF1000,1000_QL80_.jpg",
            GenreId = 1, // Sci-Fi
            Rating = 4,
            Description = "A computer hacker learns the true nature of reality.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=vKQi3bBA1y8",
            StartTime = new DateTime(2025, 8, 23, 18, 0, 0)
        },
        new()
        {
            Id = 5,
            Title = "Pulp Fiction",
            Year = 1994,
            PosterUrl = "https://cdn.europosters.eu/image/750/1288.jpg",
            GenreId = 6, // Crime
            Rating = 4,
            Description = "The lives of two mob hitmen, a boxer, and others intertwine.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=s7EdQ4FqbhY",
            StartTime = new DateTime(2025, 8, 24, 15, 0, 0)
        },
        new()
        {
            Id = 6,
            Title = "Gladiator",
            Year = 2000,
            PosterUrl = "https://m.media-amazon.com/images/I/71sj8Yt20qL.jpg",
            GenreId = 4, // Action
            Rating = 4,
            Description = "A former Roman General sets out to exact vengeance.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=owK1qxDselE",
            StartTime = new DateTime(2025, 8, 24, 19, 30, 0)
        },
        new()
        {
            Id = 7,
            Title = "Titanic",
            Year = 1997,
            PosterUrl = "https://m.media-amazon.com/images/I/71ZJ8am0mKL._UF894,1000_QL80_.jpg",
            GenreId = 5, // Romance
            Rating = 3,
            Description = "A romance blooms aboard the ill-fated RMS Titanic.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=2e-eXJ6HgkQ",
            StartTime = new DateTime(2025, 8, 23, 14, 0, 0)
        },
        new()
        {
            Id = 8,
            Title = "Avatar",
            Year = 2009,
            PosterUrl = "https://storage.googleapis.com/pod_public/750/262963.jpg",
            GenreId = 1, // Sci-Fi
            Rating = 3,
            Description = "A paraplegic Marine is dispatched to Pandora.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=5PSNL1qE6VY",
            StartTime = new DateTime(2025, 8, 25, 17, 30, 0)
        },
        new()
        {
            Id = 9,
            Title = "The Godfather",
            Year = 1972,
            PosterUrl = "https://m.media-amazon.com/images/M/MV5BNGEwYjgwOGQtYjg5ZS00Njc1LTk2ZGEtM2QwZWQ2NjdhZTE5XkEyXkFqcGc@._V1_.jpg",
            GenreId = 6, // Crime
            Rating = 4,
            Description = "The aging patriarch of an organized crime dynasty transfers control to his son.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=sY1S34973zA",
            StartTime = new DateTime(2025, 8, 25, 19, 0, 0)
        },
        new()
        {
            Id = 10,
            Title = "Fight Club",
            Year = 1999,
            PosterUrl = "https://m.media-amazon.com/images/M/MV5BOTgyOGQ1NDItNGU3Ny00MjU3LTg2YWEtNmEyYjBiMjI1Y2M5XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
            GenreId = 2, // Drama
            Rating = 4,
            Description = "An insomniac office worker forms an underground fight club.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=SUXWAEX2jlg",
            StartTime = new DateTime(2025, 8, 26, 16, 30, 0)
        },
        new()
        {
            Id = 11,
            Title = "The Lion King",
            Year = 1994,
            PosterUrl = "https://cdn.europosters.eu/image/1300/76297.jpg",
            GenreId = 7, // Animation
            Rating = 4,
            Description = "A young lion prince flees his kingdom only to learn the meaning of responsibility.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=4sj1MT05lAA",
            StartTime = new DateTime(2025, 8, 26, 14, 0, 0)
        },
        new()
        {
            Id = 12,
            Title = "Whiplash",
            Year = 2014,
            PosterUrl = "https://upload.wikimedia.org/wikipedia/uk/archive/0/01/20160208075323%21Whiplash_poster.jpg",
            GenreId = 2, // Drama
            Rating = 4,
            Description = "A promising young drummer enrolls at a cut-throat music conservatory.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=7d_jQycdQGo",
            StartTime = new DateTime(2025, 8, 27, 15, 30, 0)
        },
        new()
        {
            Id = 13,
            Title = "The Prestige",
            Year = 2006,
            PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTM3MzQ5MjQ5OF5BMl5BanBnXkFtZTcwMTQ3NzMzMw@@._V1_.jpg",
            GenreId = 8, // Mystery
            Rating = 4,
            Description = "Two magicians engage in a bitter rivalry.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=o4gHCmTQDVI",
            StartTime = new DateTime(2025, 8, 27, 18, 0, 0)
        },
        new()
        {
            Id = 14,
            Title = "The Social Network",
            Year = 2010,
            PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjlkNTE5ZTUtNGEwNy00MGVhLThmZjMtZjU1NDE5Zjk1NDZkXkEyXkFqcGc@._V1_.jpg",
            GenreId = 9, // Biography
            Rating = 3,
            Description = "The story of Facebook’s creation and its legal battles.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=lB95KLmpLR4",
            StartTime = new DateTime(2025, 8, 28, 14, 30, 0)
        },
        new()
        {
            Id = 15,
            Title = "The Grand Budapest Hotel",
            Year = 2014,
            PosterUrl = "https://storage.googleapis.com/pod_public/1300/266322.jpg",
            GenreId = 12, // Comedy
            Rating = 4,
            Description = "A concierge at a famous hotel gets involved in a theft and murder mystery.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=1Fg5iWmQjwk",
            StartTime = new DateTime(2025, 8, 28, 16, 0, 0)
        },
        new()
        {
            Id = 16,
            Title = "Mad Max: Fury Road",
            Year = 2015,
            PosterUrl = "https://m.media-amazon.com/images/M/MV5BZDRkODJhOTgtOTc1OC00NTgzLTk4NjItNDgxZDY4YjlmNDY2XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
            GenreId = 4, // Action
            Rating = 4,
            Description = "In a post-apocalyptic wasteland, Furiosa rebels against a tyrant.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=hEJnMQG9ev8",
            StartTime = new DateTime(2025, 8, 29, 15, 30, 0)
        },
        new()
        {
            Id = 17,
            Title = "Parasite",
            Year = 2019,
            PosterUrl = "https://m.media-amazon.com/images/M/MV5BYjk1Y2U4MjQtY2ZiNS00OWQyLWI3MmYtZWUwNmRjYWRiNWNhXkEyXkFqcGc@._V1_.jpg",
            GenreId = 11, // Thriller
            Rating = 4,
            Description = "Greed and class discrimination threaten a symbiotic relationship.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=5xH0HfJHsaY",
            StartTime = new DateTime(2025, 8, 29, 18, 0, 0)
        },
        new()
        {
            Id = 18,
            Title = "Joker",
            Year = 2019,
            PosterUrl = "https://m.media-amazon.com/images/M/MV5BNzY3OWQ5NDktNWQ2OC00ZjdlLThkMmItMDhhNDk3NTFiZGU4XkEyXkFqcGc@._V1_.jpg",
            GenreId = 6, // Crime
            Rating = 4,
            Description = "A mentally troubled man embarks on a downward spiral of revolution.",
            Favorite = false,
            TrailerUrl = "https://www.youtube.com/watch?v=zAGVQLHvwOY",
            StartTime = new DateTime(2025, 8, 30, 14, 0, 0)
        }
    });
        }

    }
}
