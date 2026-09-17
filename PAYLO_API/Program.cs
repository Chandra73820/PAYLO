using Microsoft.AspNetCore.HttpOverrides;
using PAYLO_API.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Logging — Serilog reads its config from appsettings.json
builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext());

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});
// Service registration (grouped, themed extensions)
builder.Services
    //ServiceCollectionExtensions
    .AddTokenServices(builder.Environment)//ServiceCollectionExtensions
    .AddJwtAuthentication(builder.Configuration, builder.Environment)//AuthenticationExtensions
    .AddCachingAndSession()//ServiceCollectionExtensions
    .AddErrorHandling()//ServiceCollectionExtensions
    .AddCoreServices();

var app = builder.Build();

// Configure the request pipeline (single call, correct order)
app.ConfigureRequestPipeline();//ApplicationBuilderExtensions

app.Run();