using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.EntityLayer.Concrete
{
    public class Serie
    {
        public int SerieId { get; set; }
        public string? SerieName { get; set; }
        public string? SerieImageUrl { get; set; }
        public string? SerieDescription { get; set; }
        public string? SerieScore { get; set; }
        public string? SerieCreatedDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
