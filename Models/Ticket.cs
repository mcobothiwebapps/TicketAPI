namespace TicketAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime EventDate { get; set; }

        
        //public static List<Ticket> GetSampleTickets()
        //{
        //    return new List<Ticket>
        //    {
        //        new Ticket { Id = 1, EventName = "Rock Concert", Type = "VIP", Price = 150.00m, EventDate = DateTime.Now.AddDays(10) },
        //        new Ticket { Id = 2, EventName = "Theater Play", Type = "Regular", Price = 45.00m, EventDate = DateTime.Now.AddDays(15) },
        //        new Ticket { Id = 3, EventName = "Sports Game", Type = "Front Row", Price = 85.00m, EventDate = DateTime.Now.AddDays(20) }
        //    };
        //}
    }
}