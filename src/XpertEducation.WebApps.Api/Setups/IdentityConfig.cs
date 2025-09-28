using Microsoft.EntityFrameworkCore;
using XpertEducation.WebApps.Api.Data;

namespace XpertEducation.WebApps.Api.Setups
{
    public static class IdentityConfig
    {
        public static WebApplicationBuilder AddIdentityConfiguration(this WebApplicationBuilder builder)
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
            }
            else
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
            }

            return builder;
        }
    }
}
