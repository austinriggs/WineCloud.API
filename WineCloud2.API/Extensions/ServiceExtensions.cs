using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WineCloud2.Models.DAL;

namespace WineCloud.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            //var connectionString = config["sqldb:connectionString"];
            //services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));

            //string dbname = config["RDS_DB_NAME"];

            ////if (string.IsNullOrEmpty(dbname)) return null;

            //string username = config["RDS_USERNAME"];
            //string password = config["RDS_PASSWORD"];
            //string hostname = config["RDS_HOSTNAME"];
            //string port = config["RDS_PORT"];

            //string connection = "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";

            string connection = "Data Source=winecloud.cqwfe32adwyu.us-west-2.rds.amazonaws.com,1433;Initial Catalog=WineCloud;Persist Security Info=True;User ID=riggs;Password=Weareawesome.0;Encrypt=False;";

            services.AddDbContext<WineCloudDbContext>(o => o.UseSqlServer(connection, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                })
            );
        }
    }
}
