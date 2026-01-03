using HadiDinner.Api.Common.Errors;
using HadiDinner.Application;
using HadiDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

// builder.Services.AddControllers((options) => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
builder.Services.AddSingleton<ProblemDetailsFactory, HadiDinnerProblemDetailsFactory>();

var app = builder.Build();

// app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
