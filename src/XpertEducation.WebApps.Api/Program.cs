using XpertEducation.WebApps.Api.Setups;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.AddIdentityConfiguration()
       .AddSwaggerConfig()
       .ResolveDependencies();

builder.Services.AddMediatR(cfg =>
{
    cfg.LicenseKey = builder.Configuration["LuckyPenny"];
    cfg.RegisterServicesFromAssemblyContaining<Program>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseDbMigrationHelper();

app.Run();
