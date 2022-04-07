using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.EntityModels.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static void SetAuditProperties(this ChangeTracker changeTracker)
        {
            changeTracker.DetectChanges();
            IEnumerable<EntityEntry> entities = changeTracker
                .Entries()
                .Where(e => e.Entity is Player && e.State == EntityState.Deleted);

            if(entities.Any())
            {
                foreach (EntityEntry entry in entities)
                {
                    var player = entry.Entity as Player;
                    player.IsDeleted = true;

                    entry.State = EntityState.Modified;
                }
            }
        }
    }
}
