using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.entities.rooms;
using Web_API_for_scheduling.Models.mappers;
using Web_API_for_scheduling.Models.mappers.audience;
using Web_API_for_scheduling.Models.mappers.day;
using Web_API_for_scheduling.Models.mappers.pair;
using Web_API_for_scheduling.Models.mappers.week;
using Web_API_for_scheduling.Models.repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TimetableDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TimetableConnectionString")));
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IMapAudience, MapAudience>();
builder.Services.AddScoped<IMapWeek, MapWeek>();
builder.Services.AddScoped<IMapPair, MapPair>();
builder.Services.AddScoped<IMapDay, MapDay>();

builder.Services.AddScoped<IRepository<Users>, UsersRepository>();
builder.Services.AddScoped<IRepository<Group>, GroupsRepository>();
builder.Services.AddScoped<IRepository<Teacher>, TeachersRepository>();
builder.Services.AddScoped<IRepository<Subject>, SubjectsRepository>();
builder.Services.AddScoped<IRepository<Semester>, SemestersRepository>();
builder.Services.AddScoped<IRepository<Week>, WeeksRepository>();
builder.Services.AddScoped<IRepository<AudienceType>, AudienceTypesRepository>();
builder.Services.AddScoped<IRepository<Audience>, AudiencesRepository>();
builder.Services.AddScoped<IRepository<Pair>, PairsRepository>();
builder.Services.AddScoped<IRepository<Day>, DaysRepository>();
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
