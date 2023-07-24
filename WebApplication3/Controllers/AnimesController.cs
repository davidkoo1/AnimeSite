using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        private readonly JsonFileAnimeService _AnimeService;

        public AnimesController(JsonFileAnimeService animeService)
        {
            _AnimeService = animeService;
        }

        [HttpGet]
        public IEnumerable<Anime> Get() => _AnimeService.GetAnimes();

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] int AnimeId, [FromQuery] int Rating)
        {
            _AnimeService.addRating(AnimeId, Rating);
            return Ok();
        }

    }
}
