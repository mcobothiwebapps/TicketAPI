namespace TicketAPI.DTOs
{
    public class TicketResponseDTO
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string TicketType { get; set; } = string.Empty;  // Renamed from "Type"
        public decimal Price { get; set; }
        public string FormattedPrice { get; set; } = string.Empty; // New calculated field
        public string EventDate { get; set; } = string.Empty;  // Formatted date
        public string EventSummary { get; set; } = string.Empty; // Combined field
    }
}