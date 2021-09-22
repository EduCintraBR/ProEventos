using System;
using System.Collections.Generic;

namespace ProEventos.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Place { get; set; }

        public DateTime? EventDate { get; set; }

        public string Theme { get; set; }

        public int AmntPeople { get; set; }

        public string ImageURL { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IEnumerable<Batch> Batches { get; set; }
        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
        public IEnumerable<EventPanelist> EventsPanelists { get; set; }
    }
}
