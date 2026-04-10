using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketModuleInfrastructure;
using DataModelsforModule;

namespace ModuleInterfaces
{
    public interface ITicketService
    {
        Task<TicketEntity> CreateTicketAsync(TicketEntity ticket);
        Task<List<TicketEntity>> GetAllTicketAsync();
        Task<TicketEntity?> GetTicketByIdAsync(int id);
        Task<TicketEntity> UpdateTicketAsync(TicketEntity ticket);
        Task DeleteTicketAsync(int id);
    }
}