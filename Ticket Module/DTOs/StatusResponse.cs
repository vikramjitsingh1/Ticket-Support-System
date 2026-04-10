using DataModelsforModule;
using ModuleInterfaces;
using ModuleServices;
using Microsoft.AspNetCore.Mvc;

namespace ModuleDTOs
{
    // DTO for updated status response
    public class StatusResponse
    {
        public int AssignmentId { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public StatusType Status { get; set; }
    }
}