using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.EntityModels.Queries
{
    public class GetPlayerByIdQuery : IRequest<Player>
    {
        public int Id { get; set; }
    }
}
