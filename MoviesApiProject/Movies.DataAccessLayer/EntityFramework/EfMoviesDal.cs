using Microsoft.EntityFrameworkCore;
using Movies.DataAccessLayer.Abstract;
using Movies.DataAccessLayer.Concrete;
using Movies.DataAccessLayer.Repositories;
using Movies.DtoLayer.MovieDtos;
using Movies.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccessLayer.EntityFramework
{
    public class EfMoviesDal : GenericRepositories<Movie>, IMovieDal
    {
        ApiContext context = new ApiContext();  

        public EfMoviesDal(ApiContext context) : base(context)
        {
        }

        public int MovieCount()
        {
           int values =  context.Movies.Count();
            return values;
        }

        public List<Movie> Last3Movies()
        {
            return _context.Movies.OrderByDescending(x => x.MovieId).Take(3).ToList();  
        }

        public List<Movie> Last5Movies()
        {
           return _context.Movies.OrderByDescending(x => x.MovieId).Take(6).ToList();        
        }

    

        public MovieWithCategoryDto MovieWithCategory(int id)
        {
            var value = _context.Movies
                .Include(x => x.Category)
                .Where(x => x.CategoryId == id)
                .Select(movie => new MovieWithCategoryDto
                {
                    MovieId = movie.MovieId,
                    MovieName = movie.MovieName,
                    MovieImageUrl = movie.MovieImageUrl,
                    MovieDescription = movie.MovieDescription,
                    MovieScore = movie.MovieScore,
                    MovieCreatedDate = movie.MovieCreatedDate,
                    CategoryId = movie.CategoryId,
                    CategoryName = movie.Category.CategoryName
                }).FirstOrDefault();

            // FirstOrDefault() İşlevi: Sorgu sonucunda birden fazla veri dönebilirse, yalnızca ilk kaydı alır.
            // Eğer sonuç boşsa (hiçbir veri dönmezse), null döndürür.

            return value;
        }
    }
}
