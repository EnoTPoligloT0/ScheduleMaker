using ScheduleMaker.Data;
using ScheduleMaker.Interfaces;
using ScheduleMaker.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using ScheduleMaker.Interfaces;
using ScheduleMaker.Repository;

var builder = WebApplication.CreateBuilder(args);

//192.168.1.113
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ApplicationDBcontext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IEventRepository, EventRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapControllers();

app.Run();

//public TimeSpan Duration => EndTime - StartTime; // Вычисляемое свойство для получения продолжительности события

// var eventDuration = event.Duration;
// string durationString = $"{eventDuration.Hours} hours, {eventDuration.Minutes} minutes";
// Console.WriteLine(durationString);


