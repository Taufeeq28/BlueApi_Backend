using Azure.Storage.Blobs;
using BlueApi_Backend.Data;
using BlueApi_Backend.Implementations;
using BlueApi_Backend.Models;
using BlueApi_Backend.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
  //  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"), sqlServerOptions =>
    //{
     //   sqlServerOptions.CommandTimeout(60); // Adjust the timeout value as needed (e.g., 60 seconds)
    //});
//});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddSingleton(u => new BlobServiceClient(
    builder.Configuration.GetConnectionString("StorageAccount")));
builder.Services.AddSingleton<IBlobService, BlobService>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

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
