using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjectManagement.API.Data;
using ProjectManagement.API.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Project Management API",
        Description = "An ASP.NET Core Web API for managing projects",
        
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddTransient<ISkillService,SkillService>();
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddTransient<IProjectsService, ProjectService>();


var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbSeeder.Seed(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
