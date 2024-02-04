using API_for_mobile_app.model;
using API_for_mobile_app.model.dto;
using API_for_mobile_app.model.dto.date;
using API_for_mobile_app.model.dto.rooms;
using API_for_mobile_app.model.entities;
using API_for_mobile_app.model.entities.date;
using API_for_mobile_app.model.entities.rooms;
using API_for_mobile_app.model.mappers;
using API_for_mobile_app.model.mappers.special_entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TimetableDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TimetableConnectionString")));

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IMapSpecialEntities<AudienceDto, Audience>, MapAudience>();
builder.Services.AddScoped<IMapSpecialEntities<WeekDto, Week>, MapWeek>();
builder.Services.AddScoped<IMapSpecialEntities<PairDto, Pair>, MapPair>();
builder.Services.AddScoped<IMapSpecialEntities<DayDto, Day>, MapDay>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
