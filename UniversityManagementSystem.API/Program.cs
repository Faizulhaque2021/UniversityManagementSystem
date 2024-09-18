using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniversityManagementSystem.API.StartupExtension;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.BLL.Service;
using UniversityManagementSystem.DLL;
using UniversityManagementSystem.DLL.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddDatabaseExtensionHelper(builder.Configuration); // Database Configuration
builder.Services.AddBLLDependency(); // All bll layer dependency add this method.
builder.Services.AddDLLDependency(); // All dll layer dependency add this method.  
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.RunMigration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
