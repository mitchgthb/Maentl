using Maentl.Auth;
using Maentl.Data;
using Maentl.Models;
using Maentl.Repository;
using Maentl.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MaentlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure())
    );

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("FakeScheme")
    .AddScheme<AuthenticationSchemeOptions, FakeAuthenticationHandler>("FakeScheme", null);

builder.Services.AddAuthorization();


var app = builder.Build();

// Auto-run DB migrations and seed if Users table is empty
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MaentlDbContext>();

    db.Database.Migrate(); // ensures migrations run at startup

    if (!db.Users.Any())
    {
        db.Users.AddRange(
            new User { DisplayName = "Alice Test", Email = "alice@example.com" },
            new User { DisplayName = "Bob Mock", Email = "bob@example.com" }
        );

        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication(); // before UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
