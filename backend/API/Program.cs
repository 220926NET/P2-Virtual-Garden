using Models;
using Services;

using Serilog;

// Setting up Serilog
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("../logs/backend-.log", rollingInterval: RollingInterval.Day, shared: true)
                .CreateLogger();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // Not safe but clears CORS issue.. we can setup a specific orgin when deploying
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IServices<Post>, PostServices>();
builder.Services.AddScoped<IServices<FriendRelationship>, FriendServices>();
builder.Services.AddScoped<IServices<Garden>, GardenServices>();
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

app.UseCors(MyAllowSpecificOrigins);

Log.Information("The API is starting");
app.Run();
Log.Information("The API has stopped");

// Dispose of logger
Log.CloseAndFlush();