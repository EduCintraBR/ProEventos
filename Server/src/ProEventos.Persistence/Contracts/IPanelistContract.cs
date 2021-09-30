using ProEventos.Domain.Entities;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Contracts
{
    public interface IPanelistContract
    {
        Task<Panelist[]> GetAllPanelistsByNameAsync(string name, bool includeEvents = false);
        Task<Panelist[]> GetAllPanelistsAsync(bool includeEvents = false);
        Task<Panelist> GetPanelistByIdAsync(int panelistId, bool includeEvents = false);
    }
}
