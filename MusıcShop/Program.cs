using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MusicShop.Business.Concrete;
using MusicShop.Business.Interface;
using MusicShop.Common.Mappers;
using MusicShop.Data.Context.Context;
using MusicShop.Data.Entities.MongoDB;
using MusicShop.Infrastructure.Concrete;
using MusicShop.Infrastructure.Interface;
using Serilog;
using StackExchange.Redis;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options => {
    options.AddPolicy("MusicShopOrigins",
        builder => {
            builder.WithOrigins("http://localhost:4200") // Replace with your frontend application's URL
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials(); // You might need this if your WebSocket server requires credentials
        });
});

// Redis configuration
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configurationOptions = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
    return ConnectionMultiplexer.Connect(configurationOptions);
});

builder.Services.AddScoped<ICacheService, RedisCacheService>();



//MSSQL configuration
builder.Services.AddDbContext<MusicShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MusicShopContext")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IBusiness<>), typeof(Business<>));

builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IUserBusiness), typeof(UserBusiness));

builder.Services.AddScoped(typeof(IUserFavouriteSongRepository), typeof(UserFavouriteSongRepository));
builder.Services.AddScoped(typeof(IUserFavouriteSongBusiness), typeof(UserFavouriteSongBusiness));

builder.Services.AddScoped<ISingleSongBusiness, SingleSongBusiness>();
builder.Services.AddScoped<ISingleSongRepository, SingleSongRepository>();

builder.Services.AddScoped<ISingleBeatBusiness, SingleBeatBusiness>();
builder.Services.AddScoped<ISingleBeatRepository, SingleBeatRepository>();

builder.Services.AddScoped<ISingerBusiness, SingerBusiness>();
builder.Services.AddScoped<ISingerRepository, SingerRepository>();

builder.Services.AddScoped<LogService>();
builder.Services.AddScoped<ILogRepository, LogRepository>();

builder.Services.AddAutoMapper(typeof(BaseMapper<,,,>));


/*
builder.Services.AddScoped<LogService>(provider =>
    new LogService(builder.Configuration.GetConnectionString("MongoDb")));
*/

//MongoDbConfig

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDB"));

builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<LogService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MusicShopOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
