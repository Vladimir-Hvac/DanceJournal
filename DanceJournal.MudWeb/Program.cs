using DanceJournal.Infrastructure.Repository.Implementation;
using DanceJournal.MudWeb.Data;
using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.Services.BS_LessonsPlanning;
using DanceJournal.Services.BS_LessonsPlanning.Interfaces;
using DanceJournal.Services.BS_NotificationManagement;
using DanceJournal.Services.BS_NotificationManagement.Gateways;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddDbContext<DanceJournalDbContext>(ServiceLifetime.Scoped);
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<ILessonPlanningRepository, LessonPlanningRepository>();
builder.Services.AddScoped<ILessonPlanning, BS_LessonsPlanning>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<DataMapping>();
builder.Services.AddDbContext<DanceJournalDbContext>(ServiceLifetime.Singleton);

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
