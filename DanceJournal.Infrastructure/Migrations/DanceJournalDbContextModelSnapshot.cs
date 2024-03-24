﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DanceJournal.Infrastructure.Migrations
{
    [DbContext(typeof(DanceJournalDbContext))]
    partial class DanceJournalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DanceJournal.Domain.Models.Invitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsSatisfied")
                        .HasColumnType("boolean");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<int>("SatisfactionLimit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LessonId");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("DanceJournal.Domain.Models.InvitationStatus", b =>
                {
                    b.Property<int>("InvitationId")
                        .HasColumnType("integer");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeclined")
                        .HasColumnType("boolean");

                    b.HasKey("InvitationId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("InvitationStatuses");
                });

            modelBuilder.Entity("DanceJournal.Domain.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("DanceJournal.Domain.Models.NotificationInvitation", b =>
                {
                    b.Property<int>("NotificationId")
                        .HasColumnType("integer");

                    b.Property<int>("InvitationId")
                        .HasColumnType("integer");

                    b.HasKey("NotificationId", "InvitationId");

                    b.HasIndex("InvitationId");

                    b.ToTable("NotificationInvitations");
                });

            modelBuilder.Entity("DanceJournal.Domain.Models.NotificationStatus", b =>
                {
                    b.Property<int>("NotificationId")
                        .HasColumnType("integer");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.HasKey("NotificationId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("NotificationStatuses");
                });

            modelBuilder.Entity("Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Finish")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LessonTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("LevelId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LessonTypeId");

                    b.HasIndex("LevelId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("LessonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LessonTypes");
                });

            modelBuilder.Entity("LessonUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsVisit")
                        .HasColumnType("boolean");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserId");

                    b.ToTable("LessonUsers");
                });

            modelBuilder.Entity("Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Coefficient")
                        .HasColumnType("double precision");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FinishDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SubscriptionTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionTypeId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("SubscriptionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContDay")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionTypes");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("LevelId")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<double>("Salary")
                        .HasColumnType("double precision");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("LevelId");

                    b.HasIndex("RoleId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DanceJournal.Domain.Models.Invitation", b =>
                {
                    b.HasOne("User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("DanceJournal.Domain.Models.InvitationStatus", b =>
                {
                    b.HasOne("DanceJournal.Domain.Models.Invitation", "Invitation")
                        .WithMany()
                        .HasForeignKey("InvitationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invitation");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("DanceJournal.Domain.Models.Notification", b =>
                {
                    b.HasOne("User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("DanceJournal.Domain.Models.NotificationInvitation", b =>
                {
                    b.HasOne("DanceJournal.Domain.Models.Invitation", "Invitation")
                        .WithMany()
                        .HasForeignKey("InvitationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DanceJournal.Domain.Models.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invitation");

                    b.Navigation("Notification");
                });

            modelBuilder.Entity("DanceJournal.Domain.Models.NotificationStatus", b =>
                {
                    b.HasOne("DanceJournal.Domain.Models.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notification");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("Lesson", b =>
                {
                    b.HasOne("LessonType", "LessonType")
                        .WithMany()
                        .HasForeignKey("LessonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LessonType");

                    b.Navigation("Level");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LessonUser", b =>
                {
                    b.HasOne("Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Subscription", b =>
                {
                    b.HasOne("SubscriptionType", "SubscriptionType")
                        .WithMany()
                        .HasForeignKey("SubscriptionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionType");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.HasOne("Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");

                    b.Navigation("Role");

                    b.Navigation("Subscription");
                });
#pragma warning restore 612, 618
        }
    }
}
