using Microsoft.EntityFrameworkCore;
using TicketModuleInfrastructure;
using DataModelsforModule;

namespace ModuleInterfaces
{
    public interface IAssignmentRepository
    {
        public Task<AssignmentEntity?> GetAssignmentByIdAsync(int id);
        public Task<AssignmentEntity> CreateAssignmentAsync(AssignmentEntity assignment);
        public Task<AssignmentEntity> UpdateStatusAsync(AssignmentEntity assignment);
    }

    public class AssignmentRepository(AppDbContext context) : IAssignmentRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<AssignmentEntity> CreateAssignmentAsync(AssignmentEntity assignment)
        {
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<AssignmentEntity?> GetAssignmentByIdAsync(int id)
        {
            return await _context.Assignments.FindAsync(id);
        }

        public async Task<AssignmentEntity> UpdateStatusAsync(AssignmentEntity assignment)
        {
            _context.Assignments.Update(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }
    }
}
