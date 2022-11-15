using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Model.DBModels;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "user API",
        Description = "An API to perform user operations",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact"),

        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license"),
        }
    });
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"MyDemoWebAPI.xml";
    options.IncludeXmlComments( Path.Combine(AppContext.BaseDirectory, xmlFile));

    /*
    var xmlFile1 = $"ModelXMLfile.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile1));
    */

});
builder.Services.AddDbContext<ApidemoContext>(options =>
    options.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=APIDemo;Trusted_Connection=True"));

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
