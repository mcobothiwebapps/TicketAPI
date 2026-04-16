using System.ComponentModel.DataAnnotations;

namespace TicketAPI.DTOs
{
    public class CreateTicketRequestDTO
    {
        [Required(ErrorMessage = "Event name is required")]
        [MinLength(3, ErrorMessage = "Event name must be at least 3 characters")]
        public string EventName { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        public DateTime EventDate { get; set; }
    }
}