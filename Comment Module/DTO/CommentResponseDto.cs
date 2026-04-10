namespace Ticket_Management.Comment_Module.DTO
{
    public class CommentResponseDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
    }
}
