using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Text;

using Xyz.Core.Entities;
using Xyz.Core.Interfaces;
using Xyz.Infrastructure.Data;
using Xyz.Infrastructure.Services;
using Xyz.Multitenancy.Data;
using Xyz.Multitenancy.Multitenancy;
using Xyz.Multitenancy.Models;
using Xyz.Multitenancy.Security;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add configurations
var multitenancyConfiguration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(
        @Directory.GetCurrentDirectory() + "/../Xyz.Multitenancy/config.json", 
        optional: false, 
        reloadOnChange: true
    )
    .Build();

var tenantsConfiguration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(
        @Directory.GetCurrentDirectory() + "/../Xyz.Multitenancy/tenants.json", 
        optional: false, 
        reloadOnChange: true
    )
    .Build();

builder.Services.Configure<MultitenancyConfiguration>(multitenancyConfiguration);
builder.Services.Configure<TenantsConfiguration>(tenantsConfiguration);


// Add servicse
builder.Services.AddScoped<ITenantAccessor<Tenant>, TenantAccessor<Tenant>>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Context for authenticating and tenant resolution
builder.Services.AddDbContext<AuthenticationDbContext>(options =>
    options.UseNpgsql(multitenancyConfiguration.GetConnectionString("XyzMultitenancy"))
        .UseSnakeCaseNamingConvention());

// Tenant specific context for tenant database, this is dynamically set after tenant is resolved per request
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(multitenancyConfiguration.GetConnectionString("XyzMultitenancy"))
        .UseSnakeCaseNamingConvention());

// For Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthenticationDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options => {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options => {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
        };
    });

// Add Policy authorizing user with tenant
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PolicyNames.RequireTenant,
        policy =>
        {
            policy.AddRequirements(new InCurrentTenantRequirement(new HttpContextAccessor()));
            policy.RequireAuthenticatedUser();
        });
});


// Cors Configuration
var  XyzCorsOrigins = "XyzCorsOrigins";

// Add Policy for Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: XyzCorsOrigins,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


// Build application
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(XyzCorsOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



