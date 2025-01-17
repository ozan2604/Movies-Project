namespace Movies.WebUI.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public object movies { get; set; }
    }
}
