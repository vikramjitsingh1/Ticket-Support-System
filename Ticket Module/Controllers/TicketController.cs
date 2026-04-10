using TicketModuleInfrastructure;
using ModuleInterfaces;
using ModuleServices;
using DataModelsforModule;
using ModuleDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;


namespace TicketController
{
    /// <summary>
    /// Manage tickets
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController(ITicketService ticketService) : ControllerBase
    {
        private readonly ITicketService _ticketService = ticketService;

        /// <summary>
        /// Create a new ticket
        /// </summary>
        // Create a new Ticket
        [HttpPost]
        public async Task<ActionResult<TicketResponse>> CreateTicket([FromBody] CreateTicketRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newTicket = new TicketEntity
                {
                    Title = request.Title,
                    Description = request.Description,
                    CreatedDate = DateTime.UtcNow
                };
                var createdTicket = await _ticketService.CreateTicketAsync(newTicket);
                var response = new TicketResponse
                {
                    TicketId = createdTicket.TId,
                    Title = createdTicket.Title,
                    Description = createdTicket.Description,
                    CreatedDate = createdTicket.CreatedDate
                };
                return CreatedAtAction(nameof(GetTicket), new { id = response.TicketId }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error creating ticket: {ex.Message}" });
            }
        }

        /// <summary>
        /// Get all tickets
        /// </summary>
        // Get all Tickets
        [HttpGet]
        public async Task<ActionResult<List<TicketResponse>>> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicketAsync();
            var response = tickets.Select(t => new TicketResponse
            {
                TicketId = t.TId,
                Title = t.Title,
                Description = t.Description,
                CreatedDate = t.CreatedDate,
            }).ToList();

            return Ok(response);
        }

        /// <summary>
        /// Get a ticket by ID
        /// </summary>
        // Get a single ticket
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketResponse>> GetTicket(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "Invalid ticket ID" });

            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();

            var response = new TicketResponse
            {
                TicketId = ticket.TId,
                Title = ticket.Title,
                Description = ticket.Description,
                CreatedDate = ticket.CreatedDate
            };

            return Ok(response);
        }

        /// <summary>
        /// Update an existing ticket
        /// </summary>
        // Update an existing ticket
        [HttpPut("{id}")]
        public async Task<ActionResult<TicketResponse>> UpdateTicket(int id, [FromBody] UpdateTicketRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTicket = await _ticketService.GetTicketByIdAsync(id);
            if (existingTicket == null)
                return NotFound(new {message = $"Ticket with ID {id} not found" });

            existingTicket.Title = request.Title;
            existingTicket.Description = request.Description;

            var updatedTicket = await _ticketService.UpdateTicketAsync(existingTicket);

            var response = new TicketResponse
            {
                TicketId = updatedTicket.TId,
                Title = updatedTicket.Title,
                Description = updatedTicket.Description,
                CreatedDate = updatedTicket.CreatedDate
            };

            return Ok(response);
        }

        /// <summary>
        /// Delete a ticket by ID
        /// </summary>
        // Delete a ticket
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();

            await _ticketService.DeleteTicketAsync(id);
            return NoContent();
        }
    }
}
