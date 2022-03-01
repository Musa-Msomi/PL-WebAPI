using MediatR;
using PremierLeague.EntityModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.EntityModels.Handlers
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Player>
    {
        private PremierLeagueContext context;

        public CreatePlayerCommandHandler(PremierLeagueContext context)
        {
            this.context = context;
        }

        public async Task<Player> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Position = request.Position,
                JerseyNumber = request.JerseyNumber,
                ClubName = request.ClubName
            };

            context.Players.Add(player);

            await  context.SaveChangesAsync();

            return player;

        }
    }
}
