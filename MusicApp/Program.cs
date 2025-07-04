using Microsoft.AspNetCore.Identity;
using MusicApp.Api.Settings;
using MusicApp.Api.Settings.Handlers;
using MusicApp.Api.Settings.Ioc;
using MusicApp.Domain.Entities;
using MusicApp.Infra.Context;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddScopeSettings();
builder.Services.AddSettingsControl(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.MigrateDatabaseAsync();

app.Run();