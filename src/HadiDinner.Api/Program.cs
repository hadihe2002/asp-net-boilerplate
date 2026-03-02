using HadiDinner.Api;
using HadiDinner.Application;
using HadiDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation().AddApplication().AddInfrastructure(builder.Configuration);

var app = builder.Build();

// builder.Services.AddControllers((options) => options.Filters.Add<ErrorHandlingFilterAttribute>());
// app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
