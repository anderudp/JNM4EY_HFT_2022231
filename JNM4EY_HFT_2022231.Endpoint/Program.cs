using Data;
using JNM4EY_HFT_2022231.Endpoint.Services;
using JNM4EY_HFT_2022231.Models;
using JNM4EY_HFT_2022231.Repository;
using Logic.Classes;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

string connStr =
    @"Data Source=(LocalDB)\MSSQLLocalDB;
    AttachDbFilename=|DataDirectory|\Database.mdf;
    Integrated Security=True;
    MultipleActiveResultSets=True";

builder.Services.AddDbContextFactory<DataContext>(b => b.UseLazyLoadingProxies().UseSqlServer(connStr));
builder.Services.AddTransient<IRepository<User>, UserRepository>();
builder.Services.AddTransient<IRepository<Todo>, TodoRepository>();
builder.Services.AddTransient<IRepository<Agenda>, AgendaRepository>();

builder.Services.AddTransient<IUserLogic, UserLogic>();
builder.Services.AddTransient<ITodoLogic, TodoLogic>();
builder.Services.AddTransient<IAgendaLogic, AgendaLogic>();

builder.Services.AddSignalR();
builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
