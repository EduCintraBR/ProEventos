using ProEventos.Domain.Entities;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contracts
{
    interface IEventContract
    {
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includePanelists);
        Task<Event[]> GetAllEventsAsync(bool includePanelists);
        Task<Event> GetEventByIdAsync(int EventId, bool includePanelists);
    }
}
