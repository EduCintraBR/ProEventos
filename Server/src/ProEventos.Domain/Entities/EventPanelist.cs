namespace ProEventos.Domain.Entities
{
    public class EventPanelist
    {
        public int PanelistId { get; set; }
        public Panelist Panelist { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}