using DataModelsforModule;
using ModuleInterfaces;
using ModuleServices;
using Microsoft.AspNetCore.Mvc;

namespace ModuleDTOs
{
    /// <summary>
    /// Request to create assignment
    /// </summary>
    public class AssignmentRequest
    {
        public required int TicketId { get; set; }
        public required int UserId { get; set; }

    }
}
