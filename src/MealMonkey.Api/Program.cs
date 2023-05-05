using MealMonkey.Api.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigurePersistence(builder.Configuration);

// Add Authentication
builder.Services.AddIdentityConfig();
builder.Services.AddAuthenticationConfig(builder.Configuration);


builder.Services.RegisterCustomServises(builder.Configuration);


//Adding MediatR
builder.Services.AddMediatR(typeof(MealMonkey.Application.IAssemplyMaker).Assembly);

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
