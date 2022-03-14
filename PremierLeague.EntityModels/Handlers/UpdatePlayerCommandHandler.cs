using MediatR;
using PremierLeague.EntityModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.EntityModels.Handlers
{
    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, Player>
    {
        private readonly PremierLeagueContext _context;

        public UpdatePlayerCommandHandler(PremierLeagueContext context)
        {
            _context = context;
        }

        public async Task<Player> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = _context.Players.Where(player => player.PlayerId == request.PlayerId).FirstOrDefault();

            if (player == null)
            {
                return null;
            }
            else
            {
                player.FirstName = request.FirstName;
                player.LastName = request.LastName; 
                player.BirthDate = request.BirthDate;
                player.Position = request.Position;
                player.JerseyNumber = request.JerseyNumber;
                player.ClubName = request.ClubName;

                await _context.SaveChangesAsync();

                return player;
            }



        }
    }
}
