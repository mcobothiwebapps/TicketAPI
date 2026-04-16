using Microsoft.EntityFrameworkCore;
using TicketAPI.Data;
using TicketAPI.Models;

namespace TicketAPI.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _context;

        public TicketService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket?> GetTicketById(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> UpdateTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
                return false;

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TicketExists(id))
                    return false;
                throw;
            }
        }

        public async Task<bool> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
                return false;

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TicketExists(int id)
        {
            return await _context.Tickets.AnyAsync(t => t.Id == id);
        }
    }
}