using Microsoft.AspNetCore.Mvc;
using Ticket_Management.Comment_Module.DTO;
using Ticket_Management.Comment_Module.Services;

namespace Ticket_Management.Comment_Module.Controller
{
    /// <summary>
    /// Manage comments for tickets
    /// </summary>
    [ApiController]
    [Route("api/tickets/{ticketId}/comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Add a comment to a ticket
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddComment(int ticketId,[FromBody] CreateCommentDto dto)
        {
            await _commentService.AddCommentAsync(ticketId, dto);

            return Ok(new
            {
                message = "Comment added successfully"
            });
        }

        /// <summary>
        /// Get all comments for a ticket
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetComments(int ticketId)
        {
            var comments = await _commentService.GetCommentsByTicketIdAsync(ticketId);

            return Ok(comments);
        }
    }
}
