using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.EntityModels.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        // caching players
        private static ConcurrentDictionary<int, Player>? playersCache;
        private PremierLeagueContext _context;

        public PlayerRepository(PremierLeagueContext premierLeague)
        {
           _context = premierLeague;

            // preloading players from db as a dictionary with playerId as key and then converting to a thread-safe concurrent dict
            if(playersCache == null)
            {
                playersCache = new ConcurrentDictionary<int, Player>(
                    _context.Players.ToDictionary(p => p.PlayerId));
            }

        }

        public async Task<Player?> CreateAsync(Player player)
        {
            EntityEntry<Player> entry = await _context.Players.AddAsync(player);
            int affected = await _context.SaveChangesAsync();
            if(affected == 1)
            {
                if(playersCache is null)
                {
                    return player;
                }
                // if player is new, add to cache, else call updatecache method
                return playersCache.AddOrUpdate(player.PlayerId, player, UpdateCache);
            }
            else
            {
                return null;                
            }
        }

        public Task<IEnumerable<Player>> GetAllAsync()
        {

            // getting from cache for performance purposes
            return Task.FromResult(playersCache is null ? Enumerable.Empty<Player>() : playersCache.Values);
        }

        public Task<Player?> GetByIdAsync(int id)
        {
            // getting from cache for performance
            if(playersCache is null)
            {
                return null!;
            }

            playersCache.TryGetValue(id, out Player? player);

            return Task.FromResult(player);
            
        }

        public async Task<Player?> UpdateAsync(int id, Player player)
        {
            // update in db
            _context.Players.Update(player);
            int affected = await _context.SaveChangesAsync();

            if (affected == 1)
            { 
                // update in cache
                return UpdateCache(id, player);
            
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            // removing from db
            var player = _context.Players.Find(id);
            if (player == null)
            {
                return null;
            }

            _context.Players.Remove(player);

            int affected = await _context.SaveChangesAsync();

            if (affected == 1)
            {
                if (playersCache is null)
                {
                    return null;
                }
                // removing from cache
                return playersCache.TryRemove(id, out player);
            }
            else
            {
                return null;
            }


        }

        private Player UpdateCache(int id, Player player)
        {
            Player? oldInfo;
            if(playersCache is not null)
            {
                if(playersCache.TryGetValue(id, out oldInfo))
                {
                    if(playersCache.TryUpdate(id,player,oldInfo))
                    {
                        return player;
                    }
                }
            }
            return null;
        }
    }
}
