using System.ComponentModel.DataAnnotations;

namespace BuisnessLogic.DTOs
{
    public class EditMovieDto
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z].*", ErrorMessage = "Title must start with a capital letter.")]
        public string Title { get; set; }
        public int Year { get; set; }
        public string PosterUrl { get; set; }
        public int Rating { get; set; }

        [MinLength(10), MaxLength(3000)]
        public string Description { get; set; }
        public bool Favorite { get; set; }
        public string TrailerUrl { get; set; }
        public DateTime StartTime { get; set; }
        public int GenreId { get; set; }
    }
}
