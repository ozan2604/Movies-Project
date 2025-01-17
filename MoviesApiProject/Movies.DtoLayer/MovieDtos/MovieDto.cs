using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DtoLayer.MovieDtos
{
    public class MovieDto
    {
        public int MovieId { get; set; }           // Filmin benzersiz kimliği
        public string MovieName { get; set; }      // Filmin adı
        public double? MovieScore { get; set; }    // Filmin puanı
        public string MovieDescription { get; set; } // Filmin açıklaması
        public string MovieImageUrl { get; set; }  // Filmin görsel URL'si
        public DateTime? MovieCreatedDate { get; set; } // Filmin oluşturulma tarihi
        public int CategoryId { get; set; }
    }
}
