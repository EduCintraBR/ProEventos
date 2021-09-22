using System;

namespace ProEventos.Domain.Entities
{
    public class Batch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public decimal Quantity { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}