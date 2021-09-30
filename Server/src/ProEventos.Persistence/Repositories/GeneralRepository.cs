using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Contracts;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Repositories
{
    public class GeneralRepository : IGeneralContract
    {
        private readonly ProEventsContext _context;

        public GeneralRepository(ProEventsContext context)
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
    }
}
