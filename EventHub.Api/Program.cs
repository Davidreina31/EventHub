using Microsoft.EntityFrameworkCore;
using Persistence.context;
using AutoMapper;
using Application.features.Event.Commands;
using Application.features.Event.Queries.GetDetailedEvent;
using Application.features.Event.Queries.GetEventList;
using Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EventHubDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventHubConnectionString"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var configuration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Event, EventListDTO>().ReverseMap();
    cfg.CreateMap<Event, EventDetailedDTO>().ReverseMap();
    cfg.CreateMap<Event, EventDTO>().ReverseMap();
});

var mapper = configuration.CreateMapper();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));


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
