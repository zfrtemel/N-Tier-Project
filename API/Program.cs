using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Runtime.Intrinsics;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Version = "v1",
        Title = "PROJECT",
        Description = "API",
        Contact = new OpenApiContact()
        {
            Email = "zaferaligunbey@gmail.com",
            Name = "zafer ali günbey",
            Url = new Uri("https://www.xxx.com")
        }
    });
})
    .AddEndpointsApiExplorer()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Secret_Key!.41")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.EnablePersistAuthorization();
    options.SwaggerEndpoint($"v1/swagger.json", "V1");
    options.DocumentTitle = "N-Tier API Documentation";
});
app.MapGet("/", () => "Running Server");

app.Run();

public partial class Program { }