using Models;
using Services;

using Serilog;

// Setting up Serilog
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("../logs/backend-.log", rollingInterval: RollingInterval.Day, shared: true)
                .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServices<User>, UserServices>();
builder.Services.AddScoped<IServices<Post>, PostServices>();
builder.Services.AddScoped<IDBAccessFactory, DBAccessFactory>();

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

Log.Information("The API is starting");
app.Run();
Log.Information("The API has stopped");

// Dispose of logger
Log.CloseAndFlush();