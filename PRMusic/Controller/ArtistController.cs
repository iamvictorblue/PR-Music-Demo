using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PRMusic.Dto;
using PRMusic.Interface;

namespace PRMusic.Controller
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {

        private readonly IArtistRepository _repo;

        public ArtistController(IArtistRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ArtistDto>>> GetArtists()
        {
            try
            {

                var output = await _repo.GetArtists();
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
        public async Task<ActionResult<ArtistDto>> GetArtistById(Guid id)
        {
            try
            {

                var output = await _repo.GetArtistById(id);
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
        public async Task<ActionResult<ArtistDto>> UpdateArtist([FromBody] ArtistDto user)
        {
            try
            {

                var output = await _repo.UpdateArtist(user);
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
        public async Task<ActionResult<Artist>> CreateArtist([FromBody] ArtistDto user)
        {
            try
            {

                var output = await _repo.CreateArtist(user);
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
        public async Task<ActionResult<bool>> DeleteArtist(Guid id)
        {
            try
            {

                var output = await _repo.DeleteArtist(id);
                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A problem happened while handling your request. {ex}");
            }
        }
    }

}