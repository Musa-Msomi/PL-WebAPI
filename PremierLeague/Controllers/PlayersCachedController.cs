using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.EntityModels.Repositories;

namespace PremierLeague.Controllers
{
    [Route("api/playerss")]
    [ApiController]
    public class PlayersCachedController : ControllerBase
    {
        private readonly IPlayerRepository playerRepository;

        public PlayersCachedController(IPlayerRepository repository)
        {
            playerRepository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Player>))]
        public async Task<IEnumerable<Player>> Get()
        {
            return await playerRepository.GetAllAsync();
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        [ProducesResponseType(200, Type = typeof(Player))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await playerRepository.GetByIdAsync(id);
            if(player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post ([FromBody] Player player)
        {
            if(player == null)
            {
                return BadRequest();
            }

            var newPlayer = await playerRepository.CreateAsync(player);

            if (newPlayer == null)
            {
                return BadRequest("Failed to add a new player");
            }
            else
            {
                return NoContent();
            
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] Player player)
        {
            if(player==null || player.PlayerId != id)
            {
                return BadRequest();
            }

            var existingPlayer = await playerRepository.GetByIdAsync(id);

            if(existingPlayer == null)
            {
                return NotFound();
            }

            await playerRepository.UpdateAsync(id, player);

            return new NoContentResult();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPlayer = await playerRepository.GetByIdAsync(id);

            if( existingPlayer == null)
            {
                return NotFound();
            }

            bool? deleted = await playerRepository.DeleteAsync(id);

            if(deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
