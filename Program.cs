using Serilog;
using SinceAllTimeHigh.Config;

var builder = WebApplication.CreateBuilder(args);
var _settings = new ApplicationSettings();
builder.Configuration.Bind(_settings);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices(_settings);
builder.Services.AddMocks(_settings);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
