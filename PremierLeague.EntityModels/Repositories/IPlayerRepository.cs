using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.EntityModels.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player?> CreateAsync (Player player);
        Task<Player?> UpdateAsync (int id,Player player);
        Task<IEnumerable<Player>> GetAllAsync ();
        Task<Player?> GetByIdAsync (int id);
        Task<bool?> DeleteAsync (int id);
    }
}
