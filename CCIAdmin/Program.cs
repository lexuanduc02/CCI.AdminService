using CCI.Model;
using CCIAdmin.ModuleRegistrations;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                .Build();

var connectionStrings = new ConnectionStringModel
{
    Default = configuration.GetConnectionString("Default"),
    Identity = configuration.GetConnectionString("Identity")
};

if (connectionStrings == null)
{
    Console.WriteLine("=======Has not define connection string yet!!!=======");
    return;
}

SerilogRegister.Initialize(configuration);

services
    .AddOptionCollection(configuration)
    .AddRepositoryCollection(connectionStrings)
    .AddServiceCollection();

builder.Host.UseSerilog();

services.AddControllers();

services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = builder.Configuration.GetValue<string>("IdentityServerUri");
                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

#region Swagger

services.AddEndpointsApiExplorer();

services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "V1",
        Title = "ITE Connect API",
        Description = "Open API for ITE Connect development integration!!!",
        Contact = new OpenApiContact
        {
            Name = "ITE ",
            Url = new Uri("https://ite.com.vn/")
        }
    });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "Enter token into field 'Bearer'",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
});

#endregion

#region Cors

services.AddCors(option =>
{
    option.AddPolicy("Default", corsPolicyBuilder =>
        corsPolicyBuilder
            .SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddAuthorization(option =>
                {
                    option.AddPolicy("admin_access", policy =>
                    {
                        policy.RequireClaim("scope", "admin");
                        policy.RequireRole("admin");
                    });
                });

#endregion

services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Default");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers().RequireAuthorization("admin_access");

app.Run();