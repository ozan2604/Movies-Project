using Movies.EntityLayer.Concrete;

namespace Movies.WebUI.Dtos.MovieDtos
{
    public class CreateMovieDto
    {
        public string MovieName { get; set; }
        public string? MovieImageUrl { get; set; }
        public string? MovieDescription { get; set; }
        public string? MovieScore { get; set; }
        public string? MovieCreatedDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
