using Microsoft.EntityFrameworkCore;
using PeliculasApi;
using PeliculasApi.Helpers;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";

builder.WebHost.UseKestrel()
    .ConfigureKestrel((context, options) =>
    {
        options.Listen(IPAddress.Any, Int32.Parse(port), listenOptions =>
         {

         });
    });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors();



var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
  
}*/

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
