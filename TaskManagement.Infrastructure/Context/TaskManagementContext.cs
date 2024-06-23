using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Context
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
            :base(options)
        {
            
        }

        public virtual DbSet<Domain.Models.Task> Tasks { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasIndex(e => e.Id);
            
            modelBuilder.Entity<Comment>()
                .Property(x => x.CommentText)
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<Comment>()
                .HasMany(x => x.Comments);

            modelBuilder.Entity<Domain.Models.Task>()
                .HasIndex(x => x.Id);

            modelBuilder.Entity<Domain.Models.Task>()
                .Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(1000);

            modelBuilder.Entity<Domain.Models.Task>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Domain.Models.Task>()
                .Property(x => x.NeedBy)
                .IsRequired(false);

            modelBuilder.Entity<Domain.Models.Task>()
                .HasMany(x => x.Logs);

            modelBuilder.Entity<Domain.Models.Task>()
                .HasMany(x => x.Comments);

            modelBuilder.Entity<Log>()
                .HasKey(x => new { x.Id, x.TaskId });

            modelBuilder.Entity<Log>()
                .HasIndex(x => x.TaskId);

            modelBuilder.Entity<Log>()
                .HasIndex(x => x.Id);

            modelBuilder.Entity<Log>()
                .Property(x => x.PreviousTaskState)
                .IsRequired();

            modelBuilder.Entity<Log>()
                .Property(x => x.ModificationDate)
                .HasDefaultValue<DateTime>(DateTime.UtcNow);

            //configure many-to-many relationship, it's optional due to ef configure this relationship explicitly
            //modelBuilder.Entity<User>()
            //    .HasMany(x => x.Tasks)
            //    .WithMany(x => x.Users);

            //configure many-to-many relationship, it's optional due to ef configure this relationship explicitly
            //modelBuilder.Entity<User>()
            //    .HasMany(x => x.Teams)
            //    .WithMany(x => x.Users);

            modelBuilder.Entity<User>().Ignore(x => x.Tasks);                
            modelBuilder.Entity<User>().Ignore(x => x.Teams);                

            modelBuilder.Entity<UserTask>()
                    .HasKey(x => new { x.UserId, x.TaskId });

            modelBuilder.Entity<Team>().Ignore(x => x.Users);

            modelBuilder.Entity<TeamUser>()
                    .HasKey(x => new { x.TeamId, x.UserId });
        }
    }
}
