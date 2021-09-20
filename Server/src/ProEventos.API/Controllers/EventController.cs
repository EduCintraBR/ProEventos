using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EventController : ControllerBase
    {
        private readonly DataContext _context;

        public EventController(DataContext context)
        {
            this._context = context;
        }
        
        [HttpGet]
        [Route("v1/events")]
        public IEnumerable<Event> Get()
        {
            return this._context.Events.ToList();
        }

        [HttpGet]
        [Route("v1/events/{id}")]
        public Event GetById(int id)
        {
            return this._context.Events.FirstOrDefault(x => x.EventId == id);
        }

        [HttpPost]
        [Route("v1/events")]
        public void Save([FromBody] Event model)
        {
            this._context.Events.Add(model);
            this._context.SaveChanges();
        }
    }
}
