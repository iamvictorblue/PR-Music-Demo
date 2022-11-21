using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PRMusic.Dto;
using PRMusic.Interface;

namespace PRMusic.Controller
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {

        private readonly ISongRepository _repo;

        public SongController(ISongRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<SongDto>>> GetSongs()
        {
            try
            {

                var output = await _repo.GetSongs();
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
        public async Task<ActionResult<SongDto>> GetSongById(Guid id)
        {
            try
            {

                var output = await _repo.GetSongById(id);
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
        public async Task<ActionResult<SongDto>> UpdateSong([FromBody] SongDto user)
        {
            try
            {

                var output = await _repo.UpdateSong(user);
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
        public async Task<ActionResult<bool>> DeleteSong ( Guid id)
        {
            try
            {

                var output = await _repo.DeleteSong(id);
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
        public async Task<ActionResult<SongDto>> AddSong([FromBody] SongDto songRecord)
        {
            try
            {

                var output = await _repo.AddSong(songRecord);
                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A problem happened while handling your request. {ex}");
            }
        }


    }

}