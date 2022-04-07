using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PremierLeague.EntityModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.EntityModels
{
    public class PremierLeagueContext : DbContext
    {
        public PremierLeagueContext()
        {

        }

        public PremierLeagueContext(DbContextOptions<PremierLeagueContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\Local_Sandbox_One;Database=PremierLeagueDB; Trusted_Connection=true");
            }
        }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion
        #region Overriding SaveChangesAsync(CancellationToken cancellationToken = default) - Soft Delete
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties();

            return await base.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region  Overriding SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) - Soft Delete
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties();

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess,cancellationToken);
        }
        #endregion

        #region Overriding SaveChanges() - Soft Delete
        public override int SaveChanges()
        {
            ChangeTracker.SetAuditProperties();
            return base.SaveChanges();
        }
        #endregion

        #region Overriding SaveChanges(bool acceptAllChangesOnSuccess)
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.SetAuditProperties();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        #endregion

     
    }
}
