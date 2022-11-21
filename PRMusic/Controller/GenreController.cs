using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PRMusic.Dto;
using PRMusic.Interface;

namespace PRMusic.Controller
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {

        private readonly IGenreRepository _repo;

        public GenreController(IGenreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GenreDto>>> GetGenres()
        {
            try
            {

                var output = await _repo.GetGenres();
                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A problem happened while handling your request. {ex}");
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GenreDto>> GetGenreById(Guid id)
        {
            try
            {

                var output = await _repo.GetGenreById(id);
                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A problem happened while handling your request. {ex}");
            }
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GenreDto>> UpdateGenre([FromBody] GenreDto user)
        {
            try
            {

                var output = await _repo.UpdateGenre(user);
                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A problem happened while handling your request. {ex}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteGenre(Guid id)
        {
            try
            {

                var output = await _repo.DeleteGenre(id);
                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A problem happened while handling your request. {ex}");
            }
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Genre>> CreateGenre([FromBody] GenreDto user)
        {
            try
            {

                var output = await _repo.CreateGenre(user);
                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A problem happened while handling your request. {ex}");
            }
        }
    }

}