using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.EntityModels.Commands
{
    public class DeletePlayerCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
