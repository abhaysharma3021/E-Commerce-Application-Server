using Microsoft.EntityFrameworkCore;
using Server.Data.DBContexts;
using Server.Data.Repositories.Contracts;
using Server.Data.Repositories.Implementations;
using Server.Business.Services;
using Server.Utilities.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add db context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found."));
});

// Map JwtSection in appsetting.json to Class object
builder.Services.Configure<JwtSection>(builder.Configuration.GetSection("JwtSection"));

// Add services
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<AdminService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
