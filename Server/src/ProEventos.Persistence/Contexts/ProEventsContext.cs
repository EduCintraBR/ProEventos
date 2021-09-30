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

            modelBuilder.Entity<Event>()
                .HasMany(e => e.SocialNetworks)
                .WithOne(rs => rs.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Panelist>()
                .HasMany(p => p.SocialNetworks)
                .WithOne(rs => rs.Panelist)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
