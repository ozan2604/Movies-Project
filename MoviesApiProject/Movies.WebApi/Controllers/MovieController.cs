using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.BusinessLayer.Abstract;
using Movies.DtoLayer.MovieDtos;
using Movies.EntityLayer.Concrete;

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var values = _movieService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMovie(CreateMovieDto createMovieDto) 
        {
            Movie movie = new Movie();

            movie.MovieName = createMovieDto.MovieName;
            movie.MovieScore= createMovieDto.MovieScore;
            movie.MovieCreatedDate = createMovieDto.MovieCreatedDate;
            movie.MovieDescription= createMovieDto.MovieDescription;
            movie.MovieImageUrl= createMovieDto.MovieImageUrl;
            movie.CategoryId= createMovieDto.CategoryId;

            _movieService.TInsert(movie);
            return Ok("Ekleme Başarılı");
          
        }

        [HttpPut]
        public IActionResult UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            Movie movie = new Movie();

            movie.MovieName = updateMovieDto.MovieName;
            movie.MovieId = updateMovieDto.MovieId;
            movie.MovieDescription = updateMovieDto.MovieDescription;
            movie.MovieImageUrl = updateMovieDto.MovieImageUrl;
            movie.CategoryId = updateMovieDto.CategoryId;
            movie.MovieScore = updateMovieDto.MovieScore;
            movie.MovieCreatedDate = updateMovieDto.MovieCreatedDate;

            _movieService.TUpdate(movie);
            return Ok("Güncelleme Başarılı");
        }


        [HttpGet("GetMovie")]
        public IActionResult GetMovie(int id)
        {
            var value = _movieService.TGetById(id);
            return Ok(value);
        }


        [HttpDelete]
        public IActionResult DeleteMovie(int id)
        {
            _movieService.TDelete(id);
            return Ok("Silme Başarılı");
        }

        [HttpGet("MovieCount")]
        public IActionResult MovieCount()
        {
            var value = _movieService.TMovieCount();
            return Ok(value);
        }


        [HttpGet("Last3Movie")]
        public IActionResult Last3Movie()
        {
            var values = _movieService.TLast3Movie();
            return Ok(values);
        }


        [HttpGet("Last5Movie")]
        public IActionResult Last5Movie()
        {
            var values = _movieService.TLast5Movie();
            return Ok(values);
        }


        [HttpGet("MovieWithCategory")]
        public IActionResult MovieWithCategory(int id)
        {
            var value = _movieService.TMovieWithCategory(id);
            return Ok(value);
        }
    }
}
