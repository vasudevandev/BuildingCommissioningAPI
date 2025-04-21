using BuildingCommissioningAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost80", policy =>
    {
        policy.WithOrigins("http://localhost:80")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container
builder.Services.AddControllers();
Console.WriteLine("📌 DB Connection String: " + builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddDbContext<CommissioningDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowLocalhost80");
app.UseAuthorization();
app.MapControllers();

app.Run();
