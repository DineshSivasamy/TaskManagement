using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Linq;

namespace Repository
{
    public class JiraBoardDbContext : DbContext
    {
        public JiraBoardDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<JiraTask> JiraTask { get; set; }
        public DbSet<TaskImage> TaskImage { get; set; }
        public DbSet<UserFavoriteJiraTask> UserFavoriteJiraTask { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(account => account.Email)
                  .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(account => account.UserName)
                  .IsUnique();

            modelBuilder.Entity<JiraTask>()
              .HasMany(e => e.Images)
              .WithOne(e => e.Task)
              .HasForeignKey(e => e.TaskId);

            modelBuilder.Entity<JiraTask>()
              .HasMany(e => e.Images)
              .WithOne(e => e.Task)
              .HasForeignKey(e => e.TaskId);


            modelBuilder.Entity<UserFavoriteJiraTask>()
              .HasOne(u => u.User)
              .WithMany(f => f.FavoriteTasks)
              .HasForeignKey(fav => fav.UserId);


            modelBuilder.Entity<UserFavoriteJiraTask>()
                .HasOne(tsk => tsk.Task)
                .WithMany(f => f.UserFavorites)
                .HasForeignKey(fav => fav.TaskId);

        }

        public override int SaveChanges()
        {
            var AddedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Added)
                .ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedDatetime").CurrentValue = DateTime.Now;
            });

            var EditedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Modified)
                .ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("LastModifiedDatetime").CurrentValue = DateTime.Now;
            });

            return base.SaveChanges();
        }
    }
}