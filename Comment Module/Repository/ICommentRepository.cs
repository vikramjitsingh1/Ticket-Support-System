using Ticket_Management.Comment_Module.Models;

namespace Ticket_Management.Comment_Module.Repository
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
        Task<List<Comment>> GetCommentsByTicketIdAsync(int ticketId);
    }
}
