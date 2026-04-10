using Microsoft.EntityFrameworkCore;
using Ticket_Management.Comment_Module.DTO;
using Ticket_Management.Comment_Module.Models;
using Ticket_Management.Comment_Module.Repository;
using TicketModuleInfrastructure;


namespace Ticket_Management.Comment_Module.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly AppDbContext _context;

        public CommentService(ICommentRepository commentRepository,AppDbContext context)
        {
            _commentRepository = commentRepository;
            _context = context;
        }


        public async Task AddCommentAsync(int ticketId, CreateCommentDto dto)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);

            if (ticket == null)
                throw new Exception("Ticket not found");

            var user = await _context.Users.FindAsync(dto.UserId);

            if (user == null)
                throw new Exception("User not found");

            var comment = new Comment
            {
                Text = dto.Text,
                TicketId = ticketId,
                UserId = dto.UserId
            };

            await _commentRepository.AddCommentAsync(comment);
        }

        public async Task<List<CommentResponseDto>> GetCommentsByTicketIdAsync(int ticketId)
        {
            var comments = await _commentRepository.GetCommentsByTicketIdAsync(ticketId);

            return comments.Select(c => new CommentResponseDto
            {
                Id = c.Id,
                Text = c.Text,
                UserId = c.UserId,
                CreatedAt = c.CreatedAt
            }).ToList();
        }


    }
}
