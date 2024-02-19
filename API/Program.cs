using Business.Interfaces;
using Business.Repositories.Abstract;
using Business.Repositories.Concrete;
using Business.Services;
using Core.Interfaces;
using Core.Services;
using DataAccess.Context;
using DataAccess.Seeders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Runtime.Intrinsics;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// add services 
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITokenService, TokenService>();
// add repositories
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// add crypto service
builder.Services.AddScoped<ICryptoService, CryptoService>();

// configurasyon kullan�labilir tekrar eden kodlar� kald�r�r
builder.Services.AddDbContext<MainDbContext>(options =>
    options.UseSqlServer("Data Source=localhost; Initial Catalog=TicketApp; Integrated Security=True; Connect Timeout=30; Encrypt=False; Trust Server Certificate=False; Application Intent=ReadWrite; Multi Subnet Failover=False"));


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
            Name = "zafer ali g�nbey",
            Url = new Uri("https://www.xxx.com")
        }
    });
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Needs valid JWT Token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("W@tPZ%EHSuzN%Jo#H>Kku^PkQ[eXW:]wZKj}FLo/mS~!<PXM1wCeOtArr<<X`}(")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

AdminSeeder.Seed(app);  //Uygulama geli�tirme a�amas�nda �a��r�yoruz. 

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