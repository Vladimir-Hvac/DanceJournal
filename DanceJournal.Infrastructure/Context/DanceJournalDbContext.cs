using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;
using System.Reflection.Emit;

public class DanceJournalDbContext : DbContext
{
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonType> LessonTypes { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
    public DbSet<LessonUser> LessonUsers { get; set; }
    public DbSet<Level> Levels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("ISsettings.json").Build();

        var connectionString = configuration?.GetConnectionString("DefaultConnection");
        if (connectionString != null)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasOne(u => u.Role).WithMany().HasForeignKey(u => u.RoleId);

        modelBuilder
            .Entity<User>()
            .HasOne(u => u.Subscription)
            .WithMany()
            .HasForeignKey(u => u.SubscriptionId);

        modelBuilder
            .Entity<Lesson>()
            .HasOne(l => l.LessonType)
            .WithMany()
            .HasForeignKey(l => l.LessonTypeId);

        modelBuilder.Entity<Lesson>().HasOne(l => l.Room).WithMany().HasForeignKey(l => l.RoomId);
        modelBuilder.Entity<Lesson>().HasOne(l => l.Level).WithMany().HasForeignKey(l => l.LevelId);

        modelBuilder
            .Entity<LessonUser>()
            .HasOne(lu => lu.User)
            .WithMany()
            .HasForeignKey(lu => lu.UserId);

        modelBuilder
            .Entity<LessonUser>()
            .HasOne(lu => lu.Lesson)
            .WithMany()
            .HasForeignKey(lu => lu.LessonId);

        modelBuilder
            .Entity<Subscription>()
            .HasOne(s => s.SubscriptionType)
            .WithMany()
            .HasForeignKey(s => s.SubscriptionTypeId);

        modelBuilder.Entity<User>().HasOne(u => u.Level).WithMany().HasForeignKey(u => u.LevelId);
        modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
