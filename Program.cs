
using Microsoft.AspNetCore.Builder;
using PixAPI.Repository;
using PixAPI.Repository.Interface;
using TenisAPI.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IPixRepository, PixRepository>();
builder.Services.AddSqlServer<AppContextData>(builder.Configuration["ConnectionStrings:Database"]);

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
