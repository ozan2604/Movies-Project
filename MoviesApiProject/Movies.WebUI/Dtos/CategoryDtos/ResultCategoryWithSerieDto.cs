using Movies.EntityLayer.Concrete;

namespace Movies.WebUI.Dtos.CategoryDtos
{
    public class ResultCategoryWithSerieDto
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public List<Serie> series { get; set; }


        public int serieId { get; set; }
        public string serieName { get; set; }
        public string serieImageUrl { get; set; }
        public string serieDescription { get; set; }
        public string serieScore { get; set; }
        public string serieCreatedDate { get; set; }

    }
}
