using TicketModuleInfrastructure;
using ModuleInterfaces;
using ModuleServices;
using DataModelsforModule;
using ModuleDTOs;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentController
{
    /// <summary>
    /// Create a new assignment
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController(IAssignmentService assignment) : ControllerBase
    {
        private readonly IAssignmentService _assignment = assignment;


        /// <summary>
        /// Create a new assignment
        /// </summary>
        // Create an Assignment
        [HttpPost]
        public async Task<ActionResult> CreateAssignment([FromBody] AssignmentRequest assignmentRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignmentEntity = new AssignmentEntity
            {
                TicketId = assignmentRequest.TicketId,
                UserId = assignmentRequest.UserId,
                Status = StatusType.Active  //Default
            };

            var createdAssignment = await _assignment.CreateAssignmentAsync(assignmentEntity);
            return CreatedAtAction(nameof(GetAssignment), new { id = createdAssignment.AssignmentId }, createdAssignment);
        }

        /// <summary>
        /// Get assignment by entering assignment ID
        /// </summary>
        // Get an Assignment
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAssignment(int id)
        {
            var assignment = await _assignment.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound(new { message = $"Assignment with ID {id} not found." });
            }
            return Ok(assignment);
        }

        /// <summary>
        /// Update assignment status
        /// </summary>
        // Update the status of an Assignment
        [HttpPatch("{id}/status")]
        public async Task<ActionResult> UpdateStatus(int id, [FromBody] StatusRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedAssignment = await _assignment.UpdateStatusAsync(id, request);
                return Ok(updatedAssignment);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
