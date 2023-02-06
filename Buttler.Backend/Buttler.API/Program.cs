using System.Text;
using Buttler.Data;
using Buttler.Data.DAOs;
using Buttler.Logic.DaoInterfaces;
using Buttler.Logic.LogicImplementations;
using Buttler.Logic.LogicInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<FileContext>();
builder.Services.AddScoped<IReportDao, ReportDao>();
builder.Services.AddScoped<IReportLogic, ReportLogic>();

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAuthentication();

app.Run();