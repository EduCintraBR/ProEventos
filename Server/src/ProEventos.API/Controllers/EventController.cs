using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;
using System;
using System.Collections.Generic;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EventController : ControllerBase
    {
        public EventController(ILogger<EventController> logger)
        {
            
        }
        
        [HttpGet]
        [Route("v1/events")]
        public IEnumerable<Event> Get()
        {
            return new Event[]
            {
                new Event
                {
                    EventId = 1,
                    Theme = "Angular 11 e .NET 5",
                    Place = "São Sebastião do Paraíso",
                    Batch = "1º Lote",
                    AmntPeople = 250,
                    EventDate = DateTime.Now.AddDays(15).ToString("dd/MM/yyyy"),
                    ImageURL = "foto.jpeg"
                },
                new Event
                {
                    EventId =  2,
                    Theme = "Culto de Homens",
                    Place = "São Sebastião do Paraíso",
                    Batch = "1º Lote",
                    AmntPeople = 50,
                    EventDate = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImageURL = "foto1.jpeg"
                },
            };
        }

        [HttpGet]
        [Route("v1/events/{id}")]
        public IEnumerable<Event> GetById(int id)
        {
            return new Event[]
            {
                new Event
                {
                    EventId = 1,
                    Theme = "Angular 11 e .NET 5",
                    Place = "São Sebastião do Paraíso",
                    Batch = "1º Lote",
                    AmntPeople = 250,
                    EventDate = DateTime.Now.AddDays(15).ToString("dd/MM/yyyy"),
                    ImageURL = "foto.jpeg"
                },
                new Event
                {
                    EventId =  2,
                    Theme = "Culto de Homens",
                    Place = "São Sebastião do Paraíso",
                    Batch = "1º Lote",
                    AmntPeople = 50,
                    EventDate = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImageURL = "foto1.jpeg"
                },
            };
        }
    }
}
