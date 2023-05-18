using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using ScoringService.Services;
using ScoringService.Utility;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);


    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.WebHost.UseUrls("http://*:5004");
    builder.Services.AddSingleton<IScoringService, ScoringServices>();
    builder.Services.AddSingleton<ISubscriberClientHelper, SubscriberClientHelper>();
    builder.Services.AddHttpClient();
    var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
    GlobalDiagnosticsContext.Set("LogDirectory", logPath);
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();


    var app = builder.Build();

    if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    logger.Error(e);
    throw;
}
finally
{
    LogManager.Shutdown();
}