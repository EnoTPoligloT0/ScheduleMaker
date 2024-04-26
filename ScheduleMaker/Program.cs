using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using ScheduleMaker.Data;
using ScheduleMaker.Interfaces;
using ScheduleMaker.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.IdentityModel.Tokens;
using ScheduleMaker.Interfaces;
using ScheduleMaker.Models;
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

builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 8;
    })
    .AddEntityFrameworkStores<ApplicationDBcontext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        options.DefaultScheme =
            options.DefaultChallengeScheme =
                options.DefaultForbidScheme =
                    options.DefaultSignInScheme =
                        options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))

    };
} );

builder.Services.AddScoped<IEventRepository, EventRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthentication();

app.MapControllers();

app.Run();

//public TimeSpan Duration => EndTime - StartTime; // Вычисляемое свойство для получения продолжительности события

// var eventDuration = event.Duration;
// string durationString = $"{eventDuration.Hours} hours, {eventDuration.Minutes} minutes";
// Console.WriteLine(durationString);


