using Microsoft.EntityFrameworkCore;
using mobpsycho.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


//-------- Add services to the container ----------//


builder.Services.AddControllers(); // Add controllers

// Read more about conf. DBContext https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.entityframeworkservicecollectionextensions.adddbcontext
// ConnectionStrings
var MyLocalConnection = builder.Configuration.GetConnectionString("mobpsychoLocalDB");

builder.Services.AddDbContext<MobpsychoDbContext>(options => options.UseSqlServer(MyLocalConnection));


builder.Services.AddSwaggerGen(); // Swagger

// Read more about CORS - https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // Example to allow origins from Angular Applications
                          policy.WithOrigins("http://localhost:4200") // if u want to deploy, configure CORS!!
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);


//-------- End of the container ----------//


var app = builder.Build();

// Read more about Swashbuckle - https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle
if (app.Environment.IsDevelopment()) // Development Environment
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction()) // Production Environment (Lambda Deployed) check security :)
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var myString = "letsReadTheApiDoc"; // Swagger Doc Production Environment
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = myString;
    });
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal API on AWS Lambda");

app.Run();
