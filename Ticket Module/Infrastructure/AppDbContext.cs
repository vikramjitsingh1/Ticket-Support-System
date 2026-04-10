using DataModelsforModule;
using Microsoft.EntityFrameworkCore;
using Ticket_Management.Comment_Module.Models;

namespace TicketModuleInfrastructure
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AssignmentEntity> Assignments { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure relationships

            // Ticket to Assignment (One-to-Many)
            modelBuilder.Entity<AssignmentEntity>()
                .HasOne(a => a.Ticket)
                .WithMany(t => t.Assignments)
                .HasForeignKey(a => a.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            // User to Assignment (One-to-Many)
            modelBuilder.Entity<AssignmentEntity>()
                .HasOne(a => a.User)
                .WithMany(u => u.Assignments)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}