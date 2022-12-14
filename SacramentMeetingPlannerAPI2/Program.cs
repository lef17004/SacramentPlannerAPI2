using PlannerApi.Models;
using PlannerApi.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.Configure<SacramentPlannerDBSettings>(builder.Configuration.GetSection("SacramentPlannerDB"));
builder.Services.Configure<SpeakerNameDBSettings>(builder.Configuration.GetSection("SacramentPlannerDB"));

builder.Services.AddSingleton<ProgramService>();
builder.Services.AddSingleton<SpeakerNameService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
