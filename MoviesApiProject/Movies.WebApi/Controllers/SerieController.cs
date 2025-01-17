using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.BusinessLayer.Abstract;
using Movies.DtoLayer.SerieDtos;
using Movies.EntityLayer.Concrete;

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private readonly ISerieService _serieService;

        public SerieController(ISerieService serieService)
        {
            _serieService = serieService;
        }
        [HttpGet]
        public IActionResult SerieList()
        {
            var values = _serieService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSerie(SerieCreateDto createSerieDto)
        {
            Serie serie = new Serie();

            serie.SerieName = createSerieDto.SerieName;
            serie.SerieDescription = createSerieDto.SerieDescription;
            serie.SerieImageUrl = createSerieDto.SerieImageUrl;
            serie.CategoryId = createSerieDto.CategoryId;
            serie.SerieScore = createSerieDto.SerieScore;
            serie.SerieCreatedDate = createSerieDto.SerieCreatedDate;

            _serieService.TInsert(serie);
            return Ok("Ekleme Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateSerie(UpdateSerieDto updateSerieDto)
        {
            Serie serie = new Serie();
            serie.SerieName = updateSerieDto.SerieName;
            serie.SerieId = updateSerieDto.SerieId;
            serie.SerieDescription = updateSerieDto.SerieDescription;
            serie.SerieImageUrl = updateSerieDto.SerieImageUrl;
            serie.CategoryId = updateSerieDto.CategoryId;
            serie.SerieScore = updateSerieDto.SerieScore;
            serie.SerieCreatedDate = updateSerieDto.SerieCreatedDate;
            _serieService.TUpdate(serie);
            return Ok("Güncelleme Başarılı");
        }

        [HttpGet("GetSerie")]
        public IActionResult GetSerie(int id)
        {
            var value = _serieService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult DeleteSerie(int id)
        {
            _serieService.TDelete(id);
            return Ok("Silme Başarılı");
        }
        [HttpGet("Last3Serie")]
        public IActionResult Last3Serie()
        {
            var values = _serieService.TLast3Serie();
            return Ok(values);
        }
        [HttpGet("SerieWithCategory")]
        public IActionResult SerieWithCategory(int id)
        {
            var values = _serieService.TSerieWithCategory(id);
            return Ok(values);
        }
        [HttpGet("SerieCount")]
        public IActionResult SerieCount()
        {
            var value = _serieService.SerieCount();
            return Ok(value);
        }
    }
}
