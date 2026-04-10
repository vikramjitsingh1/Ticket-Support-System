using System.ComponentModel.DataAnnotations;

namespace DataModelsforModule
{
    public class AssignmentEntity
    {
        [Key]
        public int Id { get; set; }
        public int TicketId { get; set; } 
        public TicketEntity Ticket { get; set; } = null!;
        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;
        public StatusType Status { get; set; } = StatusType.Active;

    }
}
