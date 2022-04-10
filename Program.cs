using MongoSample.Infrasructure.Contracts;
using MongoSample.Infrasructure.Data;
using MediatR;
using Microsoft.AspNetCore.OData;
using MongoSample.Domain.Infrasructure.Contracts;
using MongoSample.Domain.Infrasructure.Repositories;
using MongoSample.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddOptions<ConnectionSettings>()
    .Bind(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddControllers().AddOData(options => options.Select().Expand().Filter().OrderBy().Count());

// Add services to the container.

//builder.Services.AddControllersWithViews();

builder.Services.AddControllers();

builder.Services.AddScoped<IMongoContext, MongoContext>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDomain();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
