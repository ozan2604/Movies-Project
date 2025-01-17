namespace Movies.WebUI.Dtos.MovieDtos
{
    public class ResultMovieDto
    {
        public int movieId { get; set; }
        public string movieName { get; set; }
        public string movieImageUrl { get; set; }
        public string movieDescription { get; set; }
        public string movieScore { get; set; }
        public int categoryId { get; set; }
    }
}
