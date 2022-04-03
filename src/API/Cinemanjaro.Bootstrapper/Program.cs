using Cinemanjaro.Bootstrapper.Middleware;
using MediatR;
using Cinemanjaro.Shows.API;
using Cinemanjaro.Bootstrapper.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMongoDb(builder.Configuration);

builder.Services.AddShowsModule();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCinemanjaroCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseShowsModule();

app.MapControllers();

app.Run();
