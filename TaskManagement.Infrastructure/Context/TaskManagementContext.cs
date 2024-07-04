using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Models;

namespace TaskManagement.Infrastructure.Context
{
	public class TaskManagementContext : DbContext
	{
		public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
			: base(options)
		{

		}

		public virtual DbSet<Assignment> Assignments { get; set; }
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

			modelBuilder.Entity<Comment>()
				.HasOne<Assignment>(x => x.Assignment)
				.WithMany(x => x.Comments);

			modelBuilder.Entity<Comment>()
				.HasOne<User>(x => x.User)
				.WithMany(x => x.Comments);

			modelBuilder.Entity<Assignment>()
				.HasIndex(x => x.Id);

			modelBuilder.Entity<Assignment>()
				.Property(x => x.Description)
				.IsRequired(false)
				.HasMaxLength(1000);

			modelBuilder.Entity<Assignment>()
				.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(25);

			modelBuilder.Entity<Assignment>()
				.Property(x => x.NeedBy)
				.IsRequired(false);

			modelBuilder.Entity<Assignment>()
				.HasMany(x => x.Logs);

			//modelBuilder.Entity<Domain.Models.Task>()
			//    .HasMany(x => x.Comments);

			modelBuilder.Entity<Log>()
				.HasKey(x => new { x.Id, x.AssignmentId });

			modelBuilder.Entity<Log>()
				.HasIndex(x => x.AssignmentId);

			modelBuilder.Entity<Log>()
				.HasIndex(x => x.Id);

			modelBuilder.Entity<Log>()
				.Property(x => x.PreviousTaskState)
				.IsRequired();

			modelBuilder.Entity<Log>()
				.Property(x => x.ModificationDate);

			modelBuilder.Entity<User>().Ignore(x => x.Assignments);
			modelBuilder.Entity<User>().Ignore(x => x.Teams);
			modelBuilder.Entity<Assignment>().Ignore(x => x.UserTask);

			modelBuilder.Entity<UserTask>()
					.HasKey(x => new { x.UserId, x.AssignmentId });

			modelBuilder.Entity<Team>().Ignore(x => x.Users);

			modelBuilder.Entity<TeamUser>()
					.HasKey(x => new { x.TeamId, x.UserId });
		}
	}
}
