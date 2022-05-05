using Cinemanjaro.Bootstrapper.Middleware;
using Cinemanjaro.Shows.API;
using Cinemanjaro.Bootstrapper.Extensions;
using Cinemanjaro.Movies.API;
using Cinemanjaro.Tickets.API;
using Cinemanjaro.Users.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMongoDb(builder.Configuration);

builder.Services.AddShowsModule();
builder.Services.AddMoviesModule();
builder.Services.AddTicketsModule();
builder.Services.AddUsersModule(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCinemanjaroCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAllOrigins");
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseShowsModule();
app.UseMoviesModule();
app.UseTicketsModule();
app.UseUsersModule();

app.MapControllers();

app.Run();
