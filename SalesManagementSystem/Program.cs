using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SalesManagementSystem.Mapping;
using SalesManagementSystem.Services.Implementations;
using SalesManagementSystem.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISalesService, SalesService_Manual>();

// Register the AutoMapper profiles available in the assembly and bind the ISalesService to SalesService_AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<SaleMappingProfile>();
});
//builder.Services.AddScoped<ISalesService, SalesService_AutoMapper>();

builder.Services.AddControllers();
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
