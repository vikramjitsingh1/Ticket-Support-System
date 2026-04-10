using Ticket_Management.Comment_Module.DTO;

namespace Ticket_Management.Comment_Module.Services
{
    public interface ICommentService
    {
        Task AddCommentAsync(int ticketId, CreateCommentDto dto);

        Task<List<CommentResponseDto>> GetCommentsByTicketIdAsync(int ticketI);
    }
}
