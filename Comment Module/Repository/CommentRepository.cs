using Ticket_Management.Comment_Module.Models;

using Microsoft.EntityFrameworkCore;
using TicketModuleInfrastructure;

namespace Ticket_Management.Comment_Module.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        internal object Tickets;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetCommentsByTicketIdAsync(int ticketId)
        {
            return await _context.Comments.Where(c => c.TicketId == ticketId).OrderBy(c => c.CreatedAt).ToListAsync();
        }
    }
}
