using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;

namespace ProEventos.Persistence.Contexts
{
    public class ProEventsContext : DbContext
    {
        public ProEventsContext(DbContextOptions<ProEventsContext> options) 
            : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Panelist> Panelists { get; set; }
        public DbSet<EventPanelist> EventsPanelists { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventPanelist>()
                .HasKey(PE => new {PE.EventId, PE.PanelistId});
        }

    }
}
