using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;



var builder = WebApplication.CreateBuilder(args);

Env.Load(PathHelper.GetEnvFilePath());

builder.Configuration.AddEnvironmentVariables();

var dbHost = builder.Configuration["DB_HOST"];
var dbName = builder.Configuration["DB_NAME"];
var dbUser = builder.Configuration["DB_USER"];
var dbPassword = builder.Configuration["DB_PASSWORD"];
var encrypt = builder.Configuration["Encrypt"];
var trustServerCertificate = builder.Configuration["TRUST_SERVER_CERTIFICATE"];

var connectionString = $"Server={dbHost};Database={dbName};User Id={dbUser};Password={dbPassword};Encrypt={encrypt};TrustServerCertificate={trustServerCertificate};";

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

using (var context = new AppDbContext())
{
    await context.Database.EnsureCreatedAsync();
    await context.Database.CanConnectAsync();


}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}



app.Run();
