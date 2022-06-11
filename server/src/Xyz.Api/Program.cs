using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Identity;
using Xyz.Core.Interfaces;
using Xyz.Core.Models.Configuration;
using Xyz.Infrastructure.Data;
using Xyz.Infrastructure.Services;
using Xyz.Multitenancy.Data;
using Xyz.Multitenancy.Multitenancy;
using Xyz.Multitenancy.Models;
using Xyz.Multitenancy.Security;

using Xyz.Api.Security;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.WriteIndented = true;
    });
    
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

var tenantConnectionSettings = configuration.GetSection("TenantConnectionSettings");
var smtpSettings = configuration.GetSection("SmtpSettings");
var clientSettings = configuration.GetSection("ClientSettings");

// Configuration Options Deps
builder.Services.Configure<MultitenancyConfiguration>(multitenancyConfiguration);
builder.Services.Configure<TenantsConfiguration>(tenantsConfiguration);
builder.Services.Configure<TenantConnectionSettings>(tenantConnectionSettings);
builder.Services.Configure<SmtpSettings>(smtpSettings);
builder.Services.Configure<ClientSettings>(clientSettings);

// Add servicse
builder.Services.AddScoped<ITenantAccessor<Tenant>, TenantAccessor<Tenant>>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPlansService, PlansService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IPermissionsService, PermissionsService>();
builder.Services.AddScoped<IFilesService, FilesService>();
builder.Services.AddScoped<ITenantsService, TenantsService>();
builder.Services.AddScoped<IEmailingService, EmailingService>();
builder.Services.AddScoped<ICompaniesService, CompaniesService>();

// Context for authenticating and tenant resolution
builder.Services.AddDbContext<MultitenancyDbContext>(options =>
    options.UseNpgsql(multitenancyConfiguration.GetConnectionString("XyzMultitenancy"))
        .UseSnakeCaseNamingConvention());

// Tenant specific context for tenant database, this is dynamically set after tenant is resolved per request
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(multitenancyConfiguration.GetConnectionString("XyzMultitenancy"))
        .UseSnakeCaseNamingConvention());

// For Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
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
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
        };
    });

// Add Policy authorizing user with tenant
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
        Xyz.Multitenancy.Security.PolicyNames.RequireTenant,
        policy =>
        {
            policy.AddRequirements(new InCurrentTenantRequirement(new HttpContextAccessor()));
            policy.RequireAuthenticatedUser();
        }
    );

    options.AddPolicy(
        Xyz.Api.Security.TenantPolicyNames.RequireCanTenantCreateUser,
        policy =>
        {
            policy.AddRequirements(new TenantCanCreateUserRequirement(new HttpContextAccessor()));
            policy.RequireAuthenticatedUser();
        }
    );
});


// Add Multitenancy
builder.Services.AddMultiTenancy()
    .WithResolutionStrategy<HostResolutionStrategy>()
    .WithStore<TenantsDbStore>();

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

app.UseMultiTenancy();

app.UseCors(XyzCorsOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();



