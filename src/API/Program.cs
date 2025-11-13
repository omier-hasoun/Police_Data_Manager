using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using API.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

var connString = DatabaseConnectionStringProvider.GetRequired(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connString);
});

var jwtIssuer = builder.Configuration["JWT_ISSUER"] ?? throw new InvalidOperationException();
var jwtAudience = builder.Configuration["JWT_AUDIENCE"] ?? throw new InvalidOperationException();
var jwtKey = builder.Configuration["JWT_KEY"] ?? throw new InvalidOperationException();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = jwtAudience,
        ValidIssuer = jwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(jwtKey)),


    };
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.EnsureCreatedAsync();
        await db.Database.CanConnectAsync();
    }

    app.UseDeveloperExceptionPage();
}
app.UseAuthentication();
app.UseAuthorization();


app.Run();
