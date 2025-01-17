using Movies.DtoLayer.CategoryDtos;
using Movies.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
		List<Category> CategoryWithMovie();
		List<CategoryWithMoviesDto> CategoryWithMovies();
		List<CategoryWithSerieDto> CategoryWithSerie();
		List<CategoryWithMoviesDto> CategorysWithMovies(int id);
		List<CategoryWithSerieDto> CategorysWithSeries(int id);

		public int CategoryCount();
	}
}
