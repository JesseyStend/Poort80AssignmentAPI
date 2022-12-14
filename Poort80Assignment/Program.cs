using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poort80Assignment.Context;
using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;
using Poort80Assignment.Service;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod(); 
                      });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContextPool<Poort80Assignment.Context.ApiContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeContextConnectionString")
));
builder.Services.AddScoped<ICRUDservice<Employee, EmployeeIn>, SqlEmployeeService>();
builder.Services.AddScoped<ICRUDservice<Department, DepartmentIn>, SqlDepartmentService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapGet("/", ()=> "Success");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();



app.Run();
