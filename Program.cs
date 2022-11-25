using FluentValidation;
using FluentValidationDemo.Data;
using FluentValidationDemo.InterfaceRepositories;
using FluentValidationDemo.Repository;
using FluentValidationDemo.validators;
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
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining(typeof(Customervalidator));

builder.Services.AddTransient<IBaseRepository, BaseRepository>();

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConsumerInno V2.0");
});

app.MapControllers();

app.Run();
