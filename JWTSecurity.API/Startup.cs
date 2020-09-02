using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTSecurity.API.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JWTSecurity.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // setup JWT Token validation
            services.Configure<JwtTokenValidationSettings>(Configuration.GetSection(nameof(JwtTokenValidationSettings)));
            services.AddSingleton<IJwtTokenValidationSettings, JwtTokenValidationSettingsFactory>();

            // Setup JWT Issuer Settings
            services.Configure<JwtTokenIssuerSettings>(Configuration.GetSection(nameof(JwtTokenIssuerSettings)));
            services.AddSingleton<IJwtTokenIssuerSettings, JwtTokenIssuerSettingsFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
