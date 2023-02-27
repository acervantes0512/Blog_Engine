using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework
{
    public class BlogEngineContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<EditPostUser> EditPostUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StatusPost> StatusPosts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ALEXC\\SQLEXPRESS;Initial Catalog=BlogEngine;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(r => r.InitialStatus)
                .WithMany()
                .HasForeignKey(r => r.InitialStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.FinalStatus)
                .WithMany()
                .HasForeignKey(r => r.FinalStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EditPostUser>()
                .HasOne(r => r.UserAuthor)
                .WithMany()
                .HasForeignKey(r => r.UserAuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EditPostUser>()
                .HasOne(r => r.Post)
                .WithMany()
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(r => r.UserAuthor)
                .WithMany()
                .HasForeignKey(r => r.UserAuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(r => r.Post)
                .WithMany()
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
            .HasIndex(p => p.Username)
            .IsUnique();

            modelBuilder.Entity<StatusPost>()
            .HasIndex(p => p.Name)
            .IsUnique();

        }

    }
}
