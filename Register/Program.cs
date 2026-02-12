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

var app = builder.Build();

app.AddEndPointsCustomer();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
