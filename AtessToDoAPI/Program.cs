using AtessToDoAPI;
using AtessToDoAPI.Hubs;
using AtessToDoAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
});
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AtessTodoContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AtessTodoContext")));
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("TodoPolicy", policy => policy.WithOrigins("http://localhost:4200","http://localhost:4200","http://localhost:7095","https://localhost:7095").AllowAnyHeader().AllowAnyMethod()));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CORSPolicy");
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapHub<TodoHub>("/todohub");
});
app.UseHttpsRedirection();



app.MapControllers();

app.Run();
