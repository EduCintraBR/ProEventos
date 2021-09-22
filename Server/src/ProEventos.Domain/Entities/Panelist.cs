using System.Collections.Generic;

namespace ProEventos.Domain.Entities
{
    public class Panelist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Resume { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
        public IEnumerable<EventPanelist> EventsPanelists { get; set; }
    }
}