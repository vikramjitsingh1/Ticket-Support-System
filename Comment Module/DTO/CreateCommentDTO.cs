using System.ComponentModel.DataAnnotations;

namespace Ticket_Management.Comment_Module.DTO
{
    public class CreateCommentDto
    {
        //public int TicketId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
