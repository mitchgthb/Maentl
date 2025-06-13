using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using BL.Services;
using BL.Observers;
using Maentl.SQL.Repository;
using Maentl.SQL.Repository.Users;
using Maentl.SQL.Model;
using Maentl.WebApi.Observers;
using BL.Interfaces;
using Maentl.Auth;
using Maentl.Hubs;
using Enums;
using Maentl.SQL.Repository.WorkEntries;
using Maentl.SQL.Repository.Interface; // SignalRWorkObserver lives here

var builder = WebApplication.CreateBuilder(args);

// Use MaentlDbContext from SQL.Repository
builder.Services.AddDbContext<MaentlDbContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);

// Register Business Logic services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWorkEntryService, WorkEntryService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ICalendarService, CalendarService>();
builder.Services.AddScoped<IEmailActivityService, EmailActivityService>();


// Register Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWorkEntryRepository, WorkEntryRepository>();
builder.Services.AddScoped<IRepository<Document, Guid>, Repository<Document, Guid>>();
builder.Services.AddScoped<IRepository<Project, int>, Repository<Project, int>>();
builder.Services.AddScoped<IRepository<WorkEntry, int>, Repository<WorkEntry, int>>();



// SignalR Observer pattern
builder.Services.AddScoped<IWorkObserver, SignalRWorkObserver>();
builder.Services.AddScoped<WorkObserverHubBridge>();
builder.Services.AddSignalR();

// Swagger & Auth
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("FakeScheme")
    .AddScheme<AuthenticationSchemeOptions, FakeAuthenticationHandler>("FakeScheme", null);
builder.Services.AddAuthorization();

var app = builder.Build();

// Auto-run EF Core migrations & seed default users
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MaentlDbContext>();
    db.Database.Migrate();

    // Seed users
    if (!db.Users.Any())
    {
        db.Users.AddRange(
            new User { DisplayName = "Alice Test", Email = "alice@example.com", Role = UserRole.Consultant },
            new User { DisplayName = "Bob Mock", Email = "bob@example.com", Role = UserRole.Manager }
        );
    }

    // Seed projects
    if (!db.Projects.Any())
    {
        db.Projects.Add(new Project
        {
            Name = "Client Audit 2025",
            Description = "Annual audit for client X",
            OwnerEmail = "bob@example.com",
            Status = ProjectStatus.Active,
            Deadline = DateTime.UtcNow.AddDays(30),
            CreatedBy = "seed",
            ModifiedBy = "seed"
        });
    }

    // Seed documents
    if (!db.Documents.Any())
    {
        db.Documents.Add(new Document
        {
            Title = "Kickoff Document",
            Description = "Meeting notes",
            FilePath = "https://sharepoint.com/docs/kickoff.pdf",
            SourceSystem = SourceSystem.SharePoint,
            Type = DocumentType.PDF,
            CreatedBy = "alice@example.com",
            CreatedAt = DateTime.UtcNow,
            ModifiedBy = "seed"
        });
    }

    // Seed calendar event
    if (!db.CalendarEvents.Any())
    {
        db.CalendarEvents.Add(new CalendarEvent
        {
            Subject = "Project Kickoff",
            Location = "Teams",
            StartTime = DateTime.UtcNow.AddDays(-1).AddHours(10),
            EndTime = DateTime.UtcNow.AddDays(-1).AddHours(11),
            OrganizerEmail = "bob@example.com",
            AttendeeEmail = "alice@example.com",
            UserEmail = "alice@example.com",
            SourceSystem = SourceSystem.Outlook,
            CreatedBy = "seed",
            ModifiedBy = "seed"
        });
    }

    // Seed email activity
    if (!db.EmailActivities.Any())
    {
        db.EmailActivities.Add(new EmailActivity
        {
            Id = Guid.NewGuid(),
            MessageId = "MSG-001",
            Sender = "manager@example.com",
            Recipient = "alice@example.com",
            Subject = "Final report submission required",
            SentAt = DateTime.UtcNow.AddDays(-2),
            EstimatedEffortMinutes = 45,
            ParsingStrategy = "KeywordWeighted",
            Tags = "report,deadline,finance",
            UserEmail = "alice@example.com",
            WorkEntryId = null, // or set to a valid work entry id

            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow,
            CreatedBy = "seed",
            ModifiedBy = "seed"
        });
    }

    await db.SaveChangesAsync();
}


// HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Map SignalR hubs (optional)
app.MapHub<WorkObserverHub>("/hubs/work");

app.Run();
