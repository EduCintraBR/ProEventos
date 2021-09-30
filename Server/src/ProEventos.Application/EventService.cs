using ProEventos.Application.Contracts;
using ProEventos.Domain.Entities;
using System;
using System.Threading.Tasks;
using ProEventos.Persistence.Contracts;

namespace ProEventos.Application
{
    public class EventService : IEventService
    {
        private readonly IGeneralContract _generalPersist;
        private readonly IEventContract _eventPersist;

        public EventService(IGeneralContract generalPersist, IEventContract eventPersist)
        {
            this._eventPersist = eventPersist;
            this._generalPersist = generalPersist;
        }

        public async Task<Event> AddEvents(Event model)
        {
            try
            {
                this._generalPersist.Add<Event>(model);

                if (await this._generalPersist.SaveChangesAsync())
                    return await this._eventPersist.GetEventByIdAsync(model.Id, false);

                return null;
                    
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            try
            {
                var evento = await this._eventPersist.GetEventByIdAsync(eventId, false);

                if (evento == null) return null;

                model.Id = evento.Id;

                this._generalPersist.Update<Event>(model);

                if (await this._generalPersist.SaveChangesAsync())
                    return await this._eventPersist.GetEventByIdAsync(model.Id, false);

                return null;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }   
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var evento = await this._eventPersist.GetEventByIdAsync(eventId, false);
                if (evento == null) throw new Exception("Event for delete was not found");

                this._generalPersist.Delete<Event>(evento);

                return await this._generalPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Event[]> GetAllEventsAsync(bool includePanelists = false)
        {
            try
            {
                var events = await this._eventPersist.GetAllEventsAsync(includePanelists);
                if (events == null) return null;

                return events;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includePanelists = false)
        {
            try
            {
                var events = this._eventPersist.GetAllEventsByThemeAsync(theme, includePanelists);
                if (events == null) return null;

                return events;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Event> GetEventByIdAsync(int eventId, bool includePanelists = false)
        {
            try
            {
                var evento = this._eventPersist.GetEventByIdAsync(eventId, includePanelists);
                if (evento == null) return null;

                return evento;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
