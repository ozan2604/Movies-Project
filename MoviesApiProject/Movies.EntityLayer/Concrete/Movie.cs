using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Movies.EntityLayer.Concrete
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string? MovieImageUrl { get; set; }
        public string? MovieDescription { get; set; }
        public string? MovieScore { get; set; }
        public string? MovieCreatedDate { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]

        public Category Category { get; set; }
    }
}
