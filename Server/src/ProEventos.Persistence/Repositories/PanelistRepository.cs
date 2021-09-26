using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using ProEventos.Persistence.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Repositories
{
    class PanelistRepository : IPanelistContract
    {
        private readonly ProEventsContext _context;

        public PanelistRepository(ProEventsContext context)
        {
            this._context = context;
        }

        public async Task<Panelist[]> GetAllPanelistsAsync(bool includeEvents = false)
        {
            IQueryable<Panelist> query = this._context.Panelists
                .Include(p => p.SocialNetworks);

            if (includeEvents)
                query = query.Include(p => p.EventsPanelists).ThenInclude(pe => pe.Event);

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Panelist[]> GetAllPanelistsByNameAsync(string name, bool includeEvents = false)
        {
            IQueryable<Panelist> query = this._context.Panelists
                .Include(p => p.SocialNetworks);

            if (includeEvents)
                query = query.Include(p => p.EventsPanelists).ThenInclude(pe => pe.Event);

            query = query.OrderBy(p => p.Id)
                .Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Panelist> GetPanelistByIdAsync(int panelistId, bool includeEvents = false)
        {
            IQueryable<Panelist> query = this._context.Panelists;

            if (includeEvents)
                query = query.Include(p => p.EventsPanelists).ThenInclude(pe => pe.Event);

            query = query.OrderBy(p => p.Id)
                .Where(p => p.Id == panelistId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
