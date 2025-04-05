﻿using ExerciseTracker.Data;
using ExerciseTracker.Interfaces;
using ExerciseTracker.Models;
using ExerciseTracker.Repository;
using ExerciseTracker.Services;
using ExerciseTracker.UserInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = new ConfigurationBuilder();
BuildConfig(builder);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

Log.Logger.Information("Application Starting");

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<ExerciseTrackerDbContext<Pushup>>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddTransient(typeof(IRepository<>), typeof(ExerciseRepository<>));
        services.AddTransient<IExerciseService, ExerciseService>();
        services.AddTransient<MainMenu>();
    })
    .UseSerilog()
    .Build();

var svc = ActivatorUtilities.CreateInstance<MainMenu>(host.Services);
await svc.ShowMenuAsync();

static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",optional: true)
           .AddEnvironmentVariables();
}
