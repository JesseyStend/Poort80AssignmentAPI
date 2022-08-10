using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poort80Assignment.Context;
using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;
using Poort80Assignment.Service;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContextPool<Poort80Assignment.Context.AppContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeContextConnectionString")
));
builder.Services.AddScoped<ICRUDservice<Employee>, SqlEmployeeService>();
builder.Services.AddScoped<ICRUDservice<Department>, SqlDepartmentService>();
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


app.MapGet("/", ()=> "Success");

app.Run();
