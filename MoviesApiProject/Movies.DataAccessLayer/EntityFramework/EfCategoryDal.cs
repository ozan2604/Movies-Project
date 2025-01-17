using Microsoft.EntityFrameworkCore;
using Movies.DataAccessLayer.Abstract;
using Movies.DataAccessLayer.Concrete;
using Movies.DataAccessLayer.Repositories;
using Movies.DtoLayer.CategoryDtos;
using Movies.DtoLayer.MovieDtos;
using Movies.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepositories<Category>, ICategoryDal
    {
		
		 ApiContext _context = new ApiContext();

		public EfCategoryDal(ApiContext context) : base(context)
		{

		}

		public int CategoryCount()
		{
			if (_context == null)
			{
				throw new InvalidOperationException("ApiContext is null. Check DI configuration.");
			}

			if (_context.Categories == null)
			{
				throw new InvalidOperationException("Categories DbSet is null. Verify the database connection and migrations.");
			}

			var values = _context.Categories.Count();
			return values;
		}

		public List<Category> CategoryWithMovie()
		{
			var values = _context.Categories.Include(x => x.Movies).ToList();
			return values;
		}

		public List<CategoryWithMoviesDto> CategoryWithMovies()
		{
			var values = _context.Categories
				.Include(x => x.Movies)
				.Select(category => new CategoryWithMoviesDto
			{
				CategoryId = category.CategoryId,
				CategoryName = category.CategoryName,
				Movies = category.Movies.Select(movie => new Movie
				{
					MovieId = movie.MovieId,
					MovieName = movie.MovieName,
					MovieScore = movie.MovieScore,
					MovieDescription = movie.MovieDescription,
					MovieImageUrl = movie.MovieImageUrl,
					MovieCreatedDate = movie.MovieCreatedDate

				}).ToList()
			})
		.ToList();

			return values;
		}
		public List<CategoryWithSerieDto> CategoryWithSerie()
		{
			var values = _context.Categories.Include(x => x.Series).Select(category => new CategoryWithSerieDto
			{
				CategoryId = category.CategoryId,
				CategoryName = category.CategoryName,
				Series = category.Series.Select(serie => new Serie
				{
					SerieId = serie.SerieId,
					SerieName = serie.SerieName,
					SerieScore = serie.SerieScore,
					SerieDescription = serie.SerieDescription,
					SerieImageUrl = serie.SerieImageUrl,
					SerieCreatedDate = serie.SerieCreatedDate

				}).ToList()
			})
		.ToList();

			return values;
		}
		public List<CategoryWithMoviesDto> CategorysWithMovies(int id)
		{
			var values = _context.Categories.Include(x => x.Movies).Where(x => x.CategoryId == id).Select(category => new CategoryWithMoviesDto
			{
				CategoryId = category.CategoryId,
				CategoryName = category.CategoryName,
				Movies = category.Movies.Select(movie => new Movie
				{
					MovieId = movie.MovieId,
					MovieName = movie.MovieName,
					MovieScore = movie.MovieScore,
					MovieImageUrl = movie.MovieImageUrl,    
					MovieCreatedDate = movie.MovieCreatedDate,
					MovieDescription = movie.MovieDescription

				}).ToList()
			})
		.ToList();

			return values;
		}
		public List<CategoryWithSerieDto> CategorysWithSeries(int id)
		{
			var values = _context.Categories.Include(x => x.Series).Where(x => x.CategoryId == id).Select(category => new CategoryWithSerieDto
			{
				CategoryId = category.CategoryId,
				CategoryName = category.CategoryName,
				Series = category.Series.Select(serie => new Serie
				{
					SerieId = serie.SerieId,
					SerieName = serie.SerieName,
					SerieScore = serie.SerieScore,
					SerieDescription = serie.SerieDescription,
					SerieImageUrl = serie.SerieImageUrl,
					SerieCreatedDate = serie.SerieCreatedDate

				}).ToList()
			})
		.ToList();

			return values;
		}


	}
}
