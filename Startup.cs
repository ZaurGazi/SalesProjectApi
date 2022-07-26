using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProjectApi
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
            services.AddDbContext<SalesApiDBContext>(options => options.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={System.IO.Directory.GetCurrentDirectory() + "\\App_Data\\SalesApiDB.mdf"};Integrated Security=True"));
            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddJsonOptions(ConfigureJson);

            var corsOrigins = Configuration.GetSection("CORSOrigins").GetChildren().Select(x => x.Value).ToArray();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowCORS", builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins(corsOrigins).AllowCredentials().Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("AllowCORS");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void ConfigureJson(JsonOptions op)
        {
            op.JsonSerializerOptions.PropertyNameCaseInsensitive = false;

        }
    }
}
