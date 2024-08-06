using System.Text;
using FitnessWorkoutTrackerApi.Data;
using FitnessWorkoutTrackerApi.Exceptions;
using FitnessWorkoutTrackerApi.Extensions;
using FitnessWorkoutTrackerApi.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<FitnessWorkoutTrackerDbContext>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme =
            options.DefaultChallengeScheme =
                options.DefaultForbidScheme =
                    options.DefaultSignInScheme =
                        options.DefaultScheme =
                            options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    

    
    .AddCookie(options =>
    {
        options.Cookie.Name = "{your_cookie_name}";
    })

    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        var tokenValidation = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey((Encoding.UTF8.GetBytes(builder.Configuration["BearerToken:SecurityKey"])))
        };

        options.Events = new JwtBearerEvents()
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["{your_cookie_name}"];

                return Task.CompletedTask;
            }
        };
    });


builder.Services
    .AddIdentityApiEndpoints<UserApplication>()
    .AddEntityFrameworkStores<FitnessWorkoutTrackerDbContext>()
    .AddApiEndpoints();





builder.Host.AddSerilog();

builder.Services.AddAuthorization();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddScopedServices();

builder.Services.AddHttpContextAccessor();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseExceptionHandler((_ => { }));

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapIdentityApi<UserApplication>();

app.MapControllers();

app.Run();