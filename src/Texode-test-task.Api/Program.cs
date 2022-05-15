using Texode_test_task.BLL.Services;
using Texode_test_task.BLL.Services.Interfaces;
using Texode_test_task.DAL.Cards;
using Texode_test_task.DAL.Repositories;
using Texode_test_task.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IReadData, ReadData>();
builder.Services.AddTransient<IPhoneRepository, PhoneRepository>();
builder.Services.AddTransient<IPhoneService, PhoneService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}");

app.Run();
