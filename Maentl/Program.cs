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
using Enums; // SignalRWorkObserver lives here

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

    if (!db.Users.Any())
    {
        db.Users.AddRange(
            new User { DisplayName = "Alice Test", Email = "alice@example.com", Role = UserRole.Consultant },
            new User { DisplayName = "Bob Mock", Email = "bob@example.com", Role = UserRole.Manager }
        );
        db.SaveChanges();
    }
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

// Map SignalR hubs (optional)
app.MapHub<WorkObserverHub>("/hubs/work");

app.Run();
