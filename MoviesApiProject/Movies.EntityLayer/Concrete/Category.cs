using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Serie> Series { get; set; }
    }
}
