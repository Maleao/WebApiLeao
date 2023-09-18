using Microsoft.EntityFrameworkCore;
using WebApi.Data.Contexto;
using WebApiLeao.Repository.Interface;
using WebApiLeao.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string strConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(strConnection);
});

builder.Services.AddScoped<ICursosRepository, CursosRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
