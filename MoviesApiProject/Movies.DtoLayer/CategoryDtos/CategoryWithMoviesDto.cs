using Movies.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DtoLayer.CategoryDtos
{
    public class CategoryWithMoviesDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
