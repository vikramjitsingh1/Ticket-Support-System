using DataModelsforModule;
using ModuleInterfaces;
using ModuleServices;
using Microsoft.AspNetCore.Mvc;

namespace ModuleDTOs
{
    // DTO for creating a ticket
    public class CreateTicketRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    }

    // DTO for updating a ticket
    public class UpdateTicketRequest
    {
        public required int TId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
