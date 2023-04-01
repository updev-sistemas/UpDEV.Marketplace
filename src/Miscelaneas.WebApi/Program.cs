using FluentValidation;
using System.Reflection;
using UpDEV.Marketplace.Infrastructures.DatabaseFactory.Configurations;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDatabaseFactory(builder.Configuration, "postgres");

builder.Services.RegisterRepository();

var assembly = Assembly.Load("UpDEV.Marketplace.BusinessRules.Miscelaneas.Business");
ArgumentNullException.ThrowIfNull(assembly, "Assembly [UpDEV.Marketplace.BusinessRules.Miscelaneas.Business] não foi localizado");

builder.Services.AddValidatorsFromAssembly(assembly, ServiceLifetime.Transient);

builder.Services.AddAutoMapper(cfg => cfg.AddMaps(assembly!));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly!));

_ = assembly;

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