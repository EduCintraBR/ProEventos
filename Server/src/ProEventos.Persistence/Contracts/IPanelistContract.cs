using ProEventos.Domain.Entities;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public interface IPanelistContract
    {
        Task<Panelist[]> GetAllPanelistsByNameAsync(string name, bool includeEvents);
        Task<Panelist[]> GetAllPanelistsAsync(bool includeEvents);
        Task<Panelist> GetPanelistByIdAsync(int panelistId, bool includeEvents);
    }
}
