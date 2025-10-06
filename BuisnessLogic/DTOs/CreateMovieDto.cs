namespace BuisnessLogic.DTOs
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string PosterUrl { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public bool Favorite { get; set; }
        public string TrailerUrl { get; set; }
        public DateTime StartTime { get; set; }
        public int GenreId { get; set; }
    }
}
