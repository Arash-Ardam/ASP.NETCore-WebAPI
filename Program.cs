using dotnetcoreWebAPI.Configurations;
using dotnetcoreWebAPI.Mapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<dotnetcoreWebAPI.Repos.IBookRepo, dotnetcoreWebAPI.Repos.BookRepo>();

builder.AddDb();

builder.Services.AddControllers().AddNewtonsoftJson
    (e => { e.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(); 

builder.Services.AddAutoMapper(mapper => mapper.AddProfile<BookProfile>());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI();

app.Run();

public partial class Program { }
