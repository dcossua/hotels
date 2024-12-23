using System.Text.Json.Serialization;
using hotels.Repositories;
using hotels.Repositories.Impl;


var builder = WebApplication.CreateBuilder(args);

// Configuring repository
builder.Services.AddScoped<IHotelRepository, HotelRepository>();

// Add services to the container.
builder.Services.AddControllers();
// Configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JSON serialization (enums as strings)
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

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
