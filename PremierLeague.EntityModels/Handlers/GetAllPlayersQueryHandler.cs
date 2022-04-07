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
    public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<Player>>
    {
        private readonly PremierLeagueContext _context;

        public GetAllPlayersQueryHandler(PremierLeagueContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            var players = await _context.Players.Where(b => !b.IsDeleted).ToListAsync();
            return players;
        }
    }
}
