using System.ComponentModel.DataAnnotations;

namespace DataModelsforModule
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public required string Username { get; set; }

        // Navigation properties  
        public List<AssignmentEntity> Assignments { get; set; } = new();
    }
}
