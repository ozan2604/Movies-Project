using Movies.DtoLayer.MovieDtos;
using Movies.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BusinessLayer.Abstract
{
    public interface IMovieService : IGenericService<Movie>

    {
        public int TMovieCount();
        public List<Movie> TLast3Movie();
        public List<Movie> TLast5Movie();
        public MovieWithCategoryDto TMovieWithCategory(int id);
    }
}
