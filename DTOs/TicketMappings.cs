using TicketAPI.Models;

namespace TicketAPI.DTOs
{
    public static class TicketMappings
    {
        public static TicketResponseDTO ToResponseDTO(this Ticket ticket)
        {
            return new TicketResponseDTO
            {
                Id = ticket.Id,
                EventName = ticket.EventName,
                TicketType = ticket.Type,
                Price = ticket.Price,
                FormattedPrice = ticket.Price.ToString("C"), // Currency format
                EventDate = ticket.EventDate.ToString("MMMM dd, yyyy"), // "March 28, 2026"
                EventSummary = $"{ticket.EventName} - {ticket.Type} (${ticket.Price})"
            };
        }

        public static Ticket ToModel(this CreateTicketRequestDTO dto)
        {
            return new Ticket
            {
                EventName = dto.EventName,
                Type = dto.Type,
                Price = dto.Price,
                EventDate = dto.EventDate
            };
        }

        public static void UpdateModel(this UpdateTicketRequestDTO dto, Ticket ticket)
        {
            ticket.EventName = dto.EventName;
            ticket.Type = dto.Type;
            ticket.Price = dto.Price;
            ticket.EventDate = dto.EventDate;
        }

        public static Ticket ToModel(this UpdateTicketRequestDTO dto)
        {
            return new Ticket
            {
                Id = dto.Id, // Include Id for updates
                EventName = dto.EventName,
                Type = dto.Type,
                Price = dto.Price,
                EventDate = dto.EventDate
            };
        }
    }
}