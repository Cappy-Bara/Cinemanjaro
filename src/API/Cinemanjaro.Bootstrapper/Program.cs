using Cinemanjaro.Bootstrapper.Middleware;
using Cinemanjaro.Shows.API;
using Cinemanjaro.Bootstrapper.Extensions;
using Cinemanjaro.Movies.API;
using Cinemanjaro.Tickets.API;
using Cinemanjaro.Users.API;
using Cinemanjaro.Common.DataProviders;
using Cinemanjaro.Bootstrapper.Swagger;
using Cinemanjaro.Common.Settings;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Cinemanjaro.Jobs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserDataProvider,UserDataProvider>();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddMongoDb(builder.Configuration);

builder.Services.AddShowsModule();
builder.Services.AddMoviesModule();
builder.Services.AddTicketsModule(builder.Configuration);
builder.Services.AddUsersModule(builder.Configuration);
builder.Services.AddJobs(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(gen =>
{
    gen.AddAuthorizationFieldInSwagger();
    gen.CustomSchemaIds(opt => opt.FullName);
});

builder.Services.AddCinemanjaroCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAllOrigins");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseShowsModule();
app.UseMoviesModule();
app.UseTicketsModule();
app.UseUsersModule();
app.UseJobs();

app.MapControllers();

app.Run();
