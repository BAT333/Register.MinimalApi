using Microsoft.EntityFrameworkCore;
using Register.Context;
using Register.Extensions;
using Register.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<
    Microsoft.AspNetCore.Http.Json.JsonOptions
>(options =>
    options.SerializerOptions.ReferenceHandler =
        ReferenceHandler.IgnoreCycles
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("RegisterConnection");

builder.Services.AddDbContext<RegisterContext>(
    opts =>
    {
        opts.UseSqlServer(connectionString);
    });

builder.Services.AddScoped<CustomerService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("Mypolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7197") 
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("Mypolicy");

app.AddEndPointsCustomer();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
