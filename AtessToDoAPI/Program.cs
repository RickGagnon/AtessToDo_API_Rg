using AtessToDoAPI;
using AtessToDoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AtessTodoContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AtessTodoContext")));
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("TodoPolicy", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("TodoPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
