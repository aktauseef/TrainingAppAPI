using Microsoft.EntityFrameworkCore;
using TrainingAppAPI.DataModel.Context;
using TrainingAppAPI.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddDbContext<TrainingAppAPIContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});
builder.Services.ConfigureDomainServices();
builder.Services.AddCors();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseCors(options =>                          
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRouting();
app.Run();
