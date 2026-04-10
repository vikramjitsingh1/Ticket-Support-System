using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketModuleInfrastructure;
using DataModelsforModule;

namespace ModuleInterfaces 
{
    public interface ITicketRepository
    {
        public Task<TicketEntity> CreateTicketAsync(TicketEntity ticket);
        public Task<List<TicketEntity>> GetAllTicketAsync();
        public Task<TicketEntity?> GetTicketByIdAsync(int id);
        public Task<TicketEntity> UpdateTicketAsync(TicketEntity ticket);
        public Task DeleteTicketAsync(int id);

    }

    public class TicketRepository(AppDbContext context) : ITicketRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<TicketEntity> CreateTicketAsync(TicketEntity ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }
        public async Task<List<TicketEntity>> GetAllTicketAsync()
        {
            return await _context.Tickets.ToListAsync();
        }
        public async Task<TicketEntity?> GetTicketByIdAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }
        public async Task<TicketEntity> UpdateTicketAsync(TicketEntity ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }
        public async Task DeleteTicketAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }
    }
}
