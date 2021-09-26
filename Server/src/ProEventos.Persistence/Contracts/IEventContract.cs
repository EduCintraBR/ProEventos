using ProEventos.Domain.Entities;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contracts
{
    public interface IEventContract
    {
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includePanelists = false);
        Task<Event[]> GetAllEventsAsync(bool includePanelists = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includePanelists = false);
    }
}
