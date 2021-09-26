using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain.Entities;
using ProEventos.Persistence.Contexts;
using ProEventos.Application.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            this._eventService = eventService;
        }
        
        [HttpGet]
        [Route("v1/events")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var events = await this._eventService.GetAllEventsAsync(true);
                if (events == null) return NotFound("No Events Found");

                return Ok(events);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to retrieving events. Error: {e.Message}");
            }
        }

        [HttpGet]
        [Route("v1/events/theme/{theme}")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var evento = await this._eventService.GetAllEventsByThemeAsync(theme, true);
                if (evento == null) return NotFound($"Theme: {theme} doesn't match any event");

                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to retrieving events. Error: {e.Message}");
            }
        }

        [HttpGet]
        [Route("v1/events/id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await this._eventService.GetEventByIdAsync(id, true);
                if (evento == null) return NotFound($"Id: {id} doesn't match any event");

                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to retrieving events. Error: {e.Message}");
            }
        }

        [HttpPost]
        [Route("v1/events")]
        public async Task<IActionResult> Save([FromBody] Event model)
        {
            try
            {
                var resultSave = await this._eventService.AddEvents(model);
                if (resultSave == null) return BadRequest("An error ocurred while trying to save the event");

                return Ok(resultSave);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Error to saving events. Error: {e.Message}");
            }
            
        }

        [HttpPut]
        [Route("v1/events/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Event model)
        {
            try
            {
                var resultUpdate = this._eventService.UpdateEvent(id, model);
                if (resultUpdate == null) return BadRequest("An error ocurred while trying to update the event");

                return Ok(resultUpdate);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to updating events. Error: {e.Message}");
            }
        }

        [HttpDelete]
        [Route("v1/events/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await this._eventService.DeleteEvent(id) ? 
                    Ok("Event deleted") : 
                    BadRequest("Event wasn't deleted");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to deleting events. Error: {e.Message}");
            }
        }
    }
}
