using DanceJournal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

    public DbSet<NotificationInvitation> NotificationInvitations { get; set; }

    public DbSet<NotificationStatus> NotificationStatuses { get; set; }

    public DbSet<InvitationStatus> InvitationStatuses { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Invitation> Invitations { get; set; }

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

        modelBuilder.Entity<NotificationInvitation>()
            .HasKey(e => new { e.NotificationId, e.InvitationId });

        modelBuilder
            .Entity<NotificationInvitation>()
            .HasOne(ins => ins.Notification)
            .WithMany()
            .HasForeignKey(ins => ins.NotificationId);

        modelBuilder
            .Entity<NotificationInvitation>()
            .HasOne(ins => ins.Invitation)
            .WithMany()
            .HasForeignKey(ins => ins.InvitationId);

        modelBuilder
            .Entity<NotificationStatus>()
            .HasKey(x => new { x.NotificationId, x.ReceiverId });

        modelBuilder
            .Entity<NotificationStatus>()
            .HasOne(ins => ins.Notification)
            .WithMany()
            .HasForeignKey(ins => ins.NotificationId);

        modelBuilder
            .Entity<NotificationStatus>()
            .HasOne(ins => ins.Receiver)
            .WithMany()
            .HasForeignKey(ins => ins.ReceiverId);

        modelBuilder
            .Entity<InvitationStatus>()
            .HasKey(x => new { x.InvitationId, x.ReceiverId });

        modelBuilder
            .Entity<InvitationStatus>()
            .HasOne(ins => ins.Invitation)
            .WithMany()
            .HasForeignKey(ins => ins.InvitationId);

        modelBuilder
            .Entity<InvitationStatus>()
            .HasOne(ins => ins.Receiver)
            .WithMany()
            .HasForeignKey(ins => ins.ReceiverId);

        modelBuilder
            .Entity<Notification>()
            .HasOne(n => n.Creator)
            .WithMany()
            .HasForeignKey(n => n.CreatorId);

        modelBuilder
            .Entity<Invitation>()
            .HasOne(n => n.Creator)
            .WithMany()
            .HasForeignKey(n => n.CreatorId);

        modelBuilder
            .Entity<Invitation>()
            .HasOne(n => n.Lesson)
            .WithMany()
            .HasForeignKey(n => n.LessonId);

        modelBuilder.Entity<User>().HasOne(u => u.Level).WithMany().HasForeignKey(u => u.LevelId);
        modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
