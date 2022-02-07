using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Vet.Handlers
{
    public static class JwtConfigurationHandler
    {
        public static void ConfigureJwtAuthentication(IServiceCollection services, IConfigurationSection tokenAppSetting)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddCookie()
              .AddJwtBearer(cfg =>
              {
                  cfg.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidIssuer = tokenAppSetting.GetSection("Issuer").Value,
                      ValidAudience = tokenAppSetting.GetSection("Audience").Value,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenAppSetting.GetSection("Key").Value))
                  };
              });
        }

        public static void ConfigureUseAuthentication(IApplicationBuilder app)
        {
            app.UseAuthentication();
        }
    }
}
