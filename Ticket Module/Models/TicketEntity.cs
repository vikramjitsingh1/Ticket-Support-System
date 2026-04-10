using System.ComponentModel.DataAnnotations;
using Ticket_Management.Comment_Module.Models;

namespace DataModelsforModule
{
    public class TicketEntity
    {

        [Key]
        public int TId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; } = "";
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public List<AssignmentEntity> Assignments { get; set; } = new();

        public List<Comment> Comments { get; set; } = new();
    }
}
