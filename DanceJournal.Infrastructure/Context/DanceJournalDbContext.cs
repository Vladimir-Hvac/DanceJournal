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
    public DanceJournalDbContext(DbContextOptions<DanceJournalDbContext> options)
        : base(options)
    {
        var databaseCreator = this.GetService<IRelationalDatabaseCreator>();
        databaseCreator.CreateTables();
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

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
        var configuration = new ConfigurationBuilder().AddJsonFile("libsettings.json").Build();

        var connectionString = configuration?.GetConnectionString("DefaultConnection");
        if (connectionString != null)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        modelBuilder
            .Entity<User>()
            .HasOne(u => u.Subscription)
            .WithMany(s => s.Users)
            .HasForeignKey(u => u.SubscriptionId);

        modelBuilder
            .Entity<Lesson>()
            .HasOne(l => l.LessonType)
            .WithMany(lt => lt.Lessons)
            .HasForeignKey(l => l.LessonTypeId);

        modelBuilder
            .Entity<Lesson>()
            .HasOne(l => l.Room)
            .WithMany(r => r.Lessons)
            .HasForeignKey(l => l.RoomId);

        modelBuilder
            .Entity<LessonUser>()
            .HasOne(lu => lu.User)
            .WithMany(lu => lu.LessonUsers)
            .HasForeignKey(lu => lu.UserId);

        modelBuilder
            .Entity<LessonUser>()
            .HasOne(lu => lu.Lesson)
            .WithMany(l => l.LessonUsers)
            .HasForeignKey(lu => lu.LessonId);

        modelBuilder
            .Entity<Subscription>()
            .HasOne(s => s.SubscriptionType)
            .WithMany(st => st.Subscriptions)
            .HasForeignKey(s => s.SubscriptionTypeId);

        modelBuilder
            .Entity<Level>()
            .HasMany(l => l.Users)
            .WithOne(u => u.Level)
            .HasForeignKey(u => u.LevelId);

        modelBuilder
            .Entity<Level>()
            .HasMany(l => l.Lessons)
            .WithOne(le => le.Level)
            .HasForeignKey(le => le.LevelId);

        base.OnModelCreating(modelBuilder);
    }
}
