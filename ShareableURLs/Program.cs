using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.OpenApi.Models;
using ShareableURLs.Data;
using ShareableURLs.DTOs;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Shareable URLs", Version = "v1" });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<ProductRepository>();

builder.Services
    .AddAuthentication()
    .AddBearerToken();

var app = builder.Build();

app.MapControllers().RequireAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapPost("/login", (LoginDTO dto) =>
    {
        var claimsPrincipal = new ClaimsPrincipal(
           new ClaimsIdentity(
             new[] { new Claim(ClaimTypes.Name, dto.Username) },
             BearerTokenDefaults.AuthenticationScheme
           )
         );

        return Results.SignIn(claimsPrincipal);
    });

app.Run();