using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WineCloud.API.Extensions;
using WineCloud2.API.Auth;
using WineCloud2.Domain.Abstract;
using WineCloud2.Domain.Concrete;

namespace WineCloud2.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureSqlContext(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IBottleService, BottleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICellarService, CellarService>();

            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = Configuration["Auth0:ApiIdentifier"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("write:cellars", policy => policy.Requirements.Add(new HasScopeRequirement("write:cellars", domain)));
                options.AddPolicy("write:bottles", policy => policy.Requirements.Add(new HasScopeRequirement("write:bottles", domain)));
            });

            // register the scope authorization handler
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // 2. Enable authentication middleware
            app.UseAuthentication();

            app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //      name: 'default',
            //      template: '{controller=Home}/{action=Index}/{id?}');
            //});
        }

        private Dictionary<string, string> GetAwsDbConfig(IConfiguration configuration)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (IConfigurationSection pair in configuration.GetSection("iis:env").GetChildren())
            {
                string[] keypair = pair.Value.Split(new[] { '=' }, 2);
                dict.Add(keypair[0], keypair[1]);
            }

            return dict;
        }

        private string GetRdsConnectionString()
        {
            string hostname = Configuration.GetValue<string>("RDS_HOSTNAME");
            string port = Configuration.GetValue<string>("RDS_PORT");
            string dbname = Configuration.GetValue<string>("RDS_DB_NAME");
            string username = Configuration.GetValue<string>("RDS_USERNAME");
            string password = Configuration.GetValue<string>("RDS_PASSWORD");

            return $"Data Source={hostname},{port};Initial Catalog={dbname};User ID={username};Password={password};";
        }
    }
}
