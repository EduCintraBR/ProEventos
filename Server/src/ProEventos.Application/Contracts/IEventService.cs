using ProEventos.Domain.Entities;
using System.Threading.Tasks;

namespace ProEventos.Application.Contracts
{
    public interface IEventService
    {
        Task<Event> AddEvents(Event model);
        Task<Event> UpdateEvent(int eventId, Event model);
        Task<bool> DeleteEvent(int eventId);

        Task<Event[]> GetAllEventsAsync(bool includePanelists = false);
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includePanelists = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includePanelists = false);
    }
}
