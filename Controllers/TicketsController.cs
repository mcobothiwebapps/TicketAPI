using Microsoft.AspNetCore.Mvc;
using TicketAPI.Data;
using TicketAPI.DTOs; // Add this!
using TicketAPI.Exceptions; // Add this line!
using TicketAPI.Services; // Add this with your other usings
using TicketAPI.Models;

namespace TicketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _ticketService.GetAllTickets();
            return Ok(tickets.Select(t => t.ToResponseDTO()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await _ticketService.GetTicketById(id);

            if (ticket == null)
                throw new NotFoundException($"Ticket with ID {id} was not found");

            return Ok(ticket.ToResponseDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequestDTO newTicketDto)
        {
            var newTicket = newTicketDto.ToModel();
            var createdTicket = await _ticketService.CreateTicket(newTicket);

            return CreatedAtAction(nameof(GetTicket),
                new { id = createdTicket.Id },
                createdTicket.ToResponseDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] UpdateTicketRequestDTO updatedTicketDto)
        {
            if (id != updatedTicketDto.Id)
                return BadRequest("ID mismatch");

            var ticket = updatedTicketDto.ToModel();
            var success = await _ticketService.UpdateTicket(id, ticket);

            if (!success)
                throw new NotFoundException($"Ticket with ID {id} was not found");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var success = await _ticketService.DeleteTicket(id);

            if (!success)
                throw new NotFoundException($"Ticket with ID {id} was not found");

            return NoContent();
        }
    }
}