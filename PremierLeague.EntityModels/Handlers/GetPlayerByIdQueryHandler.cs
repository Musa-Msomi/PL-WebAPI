using MediatR;
using Microsoft.EntityFrameworkCore;
using PremierLeague.EntityModels.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.EntityModels.Handlers
{
    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player>
    {
        private readonly PremierLeagueContext _context;

        public GetPlayerByIdQueryHandler(PremierLeagueContext context)
        {
            _context = context;
        }

        public async Task<Player> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.Where(player => player.PlayerId == request.Id).FirstOrDefaultAsync();

            return player;
        }
    }
}
