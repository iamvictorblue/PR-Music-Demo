using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PRMusic.Dto;
using PRMusic.Interface;

namespace PRMusic.Controller
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {

        private readonly IPlaylistRepository _repo;

        public PlaylistController(IPlaylistRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PlaylistDto>>> GetPlaylists()
        {
            try
            {

                var output = await _repo.GetPlaylists();
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
        public async Task<ActionResult<PlaylistDto>> GetPlaylistById(Guid id)
        {
            try
            {

                var output = await _repo.GetPlaylistById(id);
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
        public async Task<ActionResult<PlaylistDto>> UpdatePlaylist([FromBody] PlaylistDto user)
        {
            try
            {

                var output = await _repo.UpdatePlaylist(user);
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
        public async Task<ActionResult<PlaylistDto>> AddPlaylist([FromBody] PlaylistDto playlistRecord)
        {
            try
            {

                var output = await _repo.AddPlaylist(playlistRecord);
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
        public async Task<ActionResult<bool>> DeletePlaylist(Guid id)
        {
            try
            {

                var output = await _repo.DeletePlaylist(id);
                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A problem happened while handling your request. {ex}");
            }
        }
    }

}