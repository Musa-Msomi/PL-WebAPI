using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.EntityModels.Commands;
using PremierLeague.EntityModels.Queries;

namespace PremierLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePlayerCommand addPlayer)
        {
            await _mediator.Send(addPlayer);
            return NoContent();
        }

        [HttpGet]
        public  async Task<IActionResult> Get()
        {
           var players =  await _mediator.Send(new GetAllPlayersQuery());

            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _mediator.Send(new GetPlayerByIdQuery { Id = id });

            return Ok(player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdatePlayerCommand updatePlayer)
        {
            if(id != updatePlayer.PlayerId)
            {
                return BadRequest();
            }
            
            await _mediator.Send(updatePlayer);

            return Ok();
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await _mediator.Send(new DeletePlayerCommand { Id = id}));
        }

    }
}
