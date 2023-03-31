using Carpool.Data;
using Carpool.Services;
using Carpool.Services.Authentication;
using Carpool.Services.AuthenticationServices;
using Carpool.Services.Interfaces;
using Carpool.Services.Interfaces.Authentication;
using Carpool.API.AutoMappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddScoped<ILogInService, LogInService>();
builder.Services.AddScoped<ISignUpService, SignUpService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IRideService, RideService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddCors(option =>
{
    option.AddPolicy(name:"MyPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("MyPolicy");

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

