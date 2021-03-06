using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Identity;
using Xyz.Core.Interfaces.Multitenancy;
using Xyz.Core.Interfaces.Tenants;
using Xyz.Core.Models.Configuration;

using Xyz.Infrastructure.Data;
using Xyz.Infrastructure.Services.Multitenancy;
using Xyz.Infrastructure.Services.Tenants;

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
        x.JsonSerializerOptions.WriteIndented = true;
    });
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration Sections
var multitenancyConnectionSettings = configuration.GetSection("MultitenancyConnectionSettings");
var tenantConnectionSettings = configuration.GetSection("TenantConnectionSettings");
var smtpSettings = configuration.GetSection("SmtpSettings");
var clientSettings = configuration.GetSection("ClientSettings");
var stripeSettings = configuration.GetSection("StripeSettings");

// Configuration Options Deps
builder.Services.Configure<MultitenancyConnectionSettings>(multitenancyConnectionSettings);
builder.Services.Configure<TenantConnectionSettings>(tenantConnectionSettings);
builder.Services.Configure<SmtpSettings>(smtpSettings);
builder.Services.Configure<ClientSettings>(clientSettings);
builder.Services.Configure<StripeSettings>(stripeSettings);

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
builder.Services.AddScoped<IBillingService, BillingService>();
builder.Services.AddScoped<IPaymentProcessorService, StripePaymentProcessorService>();

var server = multitenancyConnectionSettings["Server"];
var port = multitenancyConnectionSettings["Port"];
var user = multitenancyConnectionSettings["UserId"];
var password = multitenancyConnectionSettings["Password"];
var database = multitenancyConnectionSettings["Database"];
var connectionString = $@"Server={server};Port={port};Database={database};User Id={user};Password={password};";

// Multitenancy context (shared db)
builder.Services.AddDbContext<MultitenancyDbContext>(options =>
    options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

// Tenant specific context for tenant database, this is dynamically set after tenant is resolved per request
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

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



