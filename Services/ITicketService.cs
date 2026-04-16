using TicketAPI.Models;

namespace TicketAPI.Services
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllTickets();
        Task<Ticket?> GetTicketById(int id);
        Task<Ticket> CreateTicket(Ticket ticket);
        Task<bool> UpdateTicket(int id, Ticket ticket);
        Task<bool> DeleteTicket(int id);
        Task<bool> TicketExists(int id);
    }
}