using DataModelsforModule;
using ModuleInterfaces;
using ModuleServices;
using Microsoft.AspNetCore.Mvc;

namespace ModuleDTOs
{
    // DTO for Response
    public class TicketResponse
    {
        public int TicketId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
