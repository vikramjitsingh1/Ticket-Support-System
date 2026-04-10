using System.ComponentModel.DataAnnotations;
using DataModelsforModule;

namespace Ticket_Management.Comment_Module.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } =
        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
        TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

        // Foreign key for Ticket
        public int TicketId { get; set; }

        // Foreign key for User
        public int UserId { get; set; }

        // Navigation properties
        public TicketEntity Ticket { get; set; }
        public UserEntity User { get; set; }
    }
}