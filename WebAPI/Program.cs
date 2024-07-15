using Application;
using Application.Exceptions;
using Application.Exceptions.Extensions;
using Application.Exceptions.Types;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Persistence;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserRoleManagement", Version = "v1", Description = "UserRoleManagement swagger client." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler(appError =>
    {
        appError.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                Console.WriteLine($"Something went wrong: {contextFeature.Error}");

                var message = "Internal Server Error. Please try again later.";
                var statusCode = context.Response.StatusCode;

                if (contextFeature.Error is BusinessException businessException)
                {
                    message = businessException.Message;
                    statusCode = StatusCodes.Status400BadRequest;
                    context.Response.StatusCode = statusCode;
                }

                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    StatusCode = statusCode,
                    Message = message
                }));
            }
        });
    });
}

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
