using Infrastructure.Data;
using DotNetEnv.Configuration;
using API.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables()
                     .AddDotNetEnv(PathHelper.GetEnvFilePath());

builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.EnsureCreatedAsync();
    }

    app.UseDeveloperExceptionPage();
}
// else
// {
//     app.UseHsts();
// }


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
