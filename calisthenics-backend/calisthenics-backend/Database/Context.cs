using calisthenics_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Database
{
	public class Context : DbContext
	{
		public DbSet<ForumMember> ForumMembers { get; set; }
		public DbSet<CommunityMember> CommunityMembers { get; set; }
		public DbSet<InstructorRole> InstructorRoles { get; set; }

		public DbSet<Workout> Workouts { get; set; }
		public DbSet<WorkoutType> WorkoutTypes { get; set; }
		public DbSet<WorkoutLocation> WorkoutLocations { get; set; }
		public Context(DbContextOptions<Context> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Workout>()
			.HasMany(c => c.CommunityMembers)
			.WithMany(p => p.Workouts)
			.UsingEntity<CommunityMemberWorkout>(
				j => j
					.HasOne(pt => pt.CommunityMember)
					.WithMany(t => t.CommunityMemberWorkout)
					.HasForeignKey(pt => pt.CommunityMemberId),
				j => j
					.HasOne(pt => pt.Workout)
					.WithMany(p => p.CommunityMemberWorkout)
					.HasForeignKey(pt => pt.WorkoutId),
				j =>
				{
					j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
					j.HasKey(t => new { t.CommunityMemberId, t.WorkoutId });
				});

			modelBuilder.Entity<Workout>()
			.HasMany(p => p.CommunityMembers)
			.WithMany(p => p.Workouts)
			.UsingEntity<Dictionary<string, object>>(
			"CommunityMemberWorkouts",
				j => j
			.HasOne<CommunityMember>()
			.WithMany()
			.HasForeignKey("CommunityMemberId")
			.HasConstraintName("FK_CommunityMember_CommunityMemberId")
			.OnDelete(DeleteBehavior.Cascade),
				j => j
			.HasOne<Workout>()
			.WithMany()
			.HasForeignKey("WorkoutId")
			.HasConstraintName("FK_Workouts_WorkoutId")
			.OnDelete(DeleteBehavior.ClientCascade));
		}
	}
}
