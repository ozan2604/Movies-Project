using Movies.BusinessLayer.Abstract;
using Movies.DataAccessLayer.Abstract;
using Movies.DtoLayer.MovieDtos;
using Movies.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BusinessLayer.Concrete
{
    public class MovieManager : GenericManager<Movie>, IMovieService
    {
        public readonly IMovieDal _movieDal;
        public MovieManager(IGenericDal<Movie> genericDal, IMovieDal movieDal) : base(genericDal)
        {
            _movieDal = movieDal;
        }

        public List<Movie> TLast3Movie()
        {
            return _movieDal.Last3Movies();
        }

        public List<Movie> TLast5Movie()
        {
            return _movieDal.Last5Movies(); 
        }

        public int TMovieCount()
        {
            return _movieDal.MovieCount();  
        }

        public MovieWithCategoryDto TMovieWithCategory(int id)
        {
            return _movieDal.MovieWithCategory(id); 
        }
    }
}
