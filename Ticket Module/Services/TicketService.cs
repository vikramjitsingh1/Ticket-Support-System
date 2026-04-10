using Microsoft.EntityFrameworkCore;   
using ModuleInterfaces;
using DataModelsforModule;

namespace ModuleServices
{

    //Dependency Injection for the Ticket Repository
    public class TicketService(ITicketRepository ticketrepo) : ITicketService
    {
        private readonly ITicketRepository _ticketrepo = ticketrepo;

        // Methods of Ticket Service Class
        public async Task<TicketEntity> CreateTicketAsync(TicketEntity ticket)
        {
            return await _ticketrepo.CreateTicketAsync(ticket);
        }

        public async Task<List<TicketEntity>> GetAllTicketAsync()
        {
            return await _ticketrepo.GetAllTicketAsync();
        }

        public async Task<TicketEntity?> GetTicketByIdAsync(int id)
        {
            return await _ticketrepo.GetTicketByIdAsync(id);
        }

        public async Task<TicketEntity> UpdateTicketAsync(TicketEntity ticket)
        {
            return await _ticketrepo.UpdateTicketAsync(ticket);
        }

        public async Task DeleteTicketAsync(int id)
        {
            await _ticketrepo.DeleteTicketAsync(id);
        }
    }
}
