using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PRMusic.Dto;
using PRMusic.Interface;

namespace PRMusic.Controller
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class SongPlayerController : ControllerBase
    {

        private readonly ISongPlayerRepository _repo;

        public SongPlayerController(ISongPlayerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<SongPlayerDto>>> GetSongPlayers()
        {
            try
            {

                var output = await _repo.GetSongPlayers();
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
        public async Task<ActionResult<SongPlayerDto>> GetSongPlayerById(Guid id)
        {
            try
            {

                var output = await _repo.GetSongPlayerById(id);
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
        public async Task<ActionResult<SongPlayerDto>> UpdateSongPlayer([FromBody] SongPlayerDto user)
        {
            try
            {

                var output = await _repo.UpdateSongPlayer(user);
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
        public async Task<ActionResult<bool>> DeleteSongPlayer(Guid id)
        {
            try
            {

                var output = await _repo.DeleteSongPlayer(id);
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
        public async Task<ActionResult<SongPlayer>> CreateSongPlayer([FromBody] SongPlayerDto user)
        {
            try
            {

                var output = await _repo.CreateSongPlayer(user);
                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A problem happened while handling your request. {ex}");
            }
        }
    }

}