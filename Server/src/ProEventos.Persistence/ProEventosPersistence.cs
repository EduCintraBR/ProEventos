using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using ProEventos.Persistence.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    class ProEventosPersistence : IGeneralContract, IEventContract, IPanelistContract
    {
        private readonly ProEventsContext _context;

        public ProEventosPersistence(ProEventsContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this._context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this._context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this._context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            this._context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this._context.SaveChangesAsync()) > 0;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includePanelists = false)
        {
            IQueryable<Event> query = this._context.Events
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
            IQueryable<Event> query = this._context.Events
                    .Include(e => e.Batches)
                    .Include(e => e.SocialNetworks);

            if (includePanelists)
            {
                query = query.Include(e => e.EventsPanelists)
                    .ThenInclude(pe => pe.Panelist);
            }
            query = query.Where(e => e.Theme.ToLower().Contains( theme.ToLower() ))
                .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int EventId, bool includePanelists = false)
        {
            IQueryable<Event> query = this._context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includePanelists)
                query = query.Include(e => e.EventsPanelists).ThenInclude(pe => pe.Panelist);

            query = query.OrderBy(e => e.Id);

            return await query.FirstOrDefaultAsync();
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
