using Movies.EntityLayer.Concrete;

namespace Movies.WebUI.Dtos.CategoryDtos
{
    public class ResultCategoryWithMovieDto
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public List<Movie> movies { get; set; }



        public int movieId { get; set; }
        public string movieName { get; set; }
        public object movieImageUrl { get; set; }
        public object movieDescription { get; set; }
        public object movieScore { get; set; }

        public object category { get; set; }
    }
}
