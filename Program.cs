using FluentValidationDemo.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// TODO: Use sql server
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseInMemoryDatabase("UberEats");
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented= true;
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConsumerInno V2.0");
});

app.MapControllers();

app.Run();
