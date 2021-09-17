using System;

namespace ProEventos.API.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public string Place { get; set; }

        public string EventDate { get; set; }

        public string Theme { get; set; }

        public int AmntPeople { get; set; }

        public string Batch { get; set; }

        public string ImageURL { get; set; }
    }
}