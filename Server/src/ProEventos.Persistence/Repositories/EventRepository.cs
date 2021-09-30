using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Repositories
{
    public class EventRepository : IEventContract
    {
        private readonly ProEventsContext _context;

        public EventRepository(ProEventsContext context)
        {
            this._context = context;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includePanelists = false)
        {
            IQueryable<Event> query = this._context.Events.AsNoTracking()
                    .Include(e => e.Batches)
                    .Include(e => e.SocialNetworks);

            if (includePanelists)
            {
                query = query.Include(e => e.EventsPanelists)
                    .ThenInclude(pe => pe.Panelist);
            }
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includePanelists = false)
        {
            IQueryable<Event> query = this._context.Events.AsNoTracking()
                    .Include(e => e.Batches)
                    .Include(e => e.SocialNetworks);

            if (includePanelists)
            {
                query = query.Include(e => e.EventsPanelists)
                    .ThenInclude(pe => pe.Panelist);
            }
            query = query.Where(e => e.Theme.ToLower().Contains(theme.ToLower()))
                .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includePanelists = false)
        {
            IQueryable<Event> query = this._context.Events.AsNoTracking()
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includePanelists)
                query = query.Include(e => e.EventsPanelists).ThenInclude(pe => pe.Panelist);

            query = query.OrderBy(e => e.Id).Where(e => e.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
