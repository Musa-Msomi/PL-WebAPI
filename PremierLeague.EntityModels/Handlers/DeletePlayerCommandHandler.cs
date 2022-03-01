using MediatR;
using Microsoft.EntityFrameworkCore;
using PremierLeague.EntityModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.EntityModels.Handlers
{
    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, int>
    {
        private readonly PremierLeagueContext _context;

        public DeletePlayerCommandHandler(PremierLeagueContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.Where(player => player.PlayerId == request.Id).FirstOrDefaultAsync();

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return player.PlayerId;
        }
    }
}
