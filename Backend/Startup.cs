using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VSTSBuildDashboard.Controllers;

namespace VSTSBuildDashboard
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment env)
        {
            var cultureInfo = new CultureInfo("en-US");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.secrets.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            Environment = env;
        }

        public IConfigurationRoot Configuration { get; }

        public IHostingEnvironment Environment { get; }



        public void ConfigureServices(IServiceCollection services)
        {
            var setting = new AppSettings();
            Configuration.Bind(setting);

            services.AddHttpClient<Services.VstsClient>("VSTS", factory =>
            {
                factory.BaseAddress = new Uri(Configuration["VisualStudioTeamServices:BaseAddress"]);
                factory.DefaultRequestHeaders.Add("Accept", "application/json");
                factory.DefaultRequestHeaders.Add("Authorization", $"Basic {Configuration["VisualStudioTeamServices:PersonalAccessToken"]}");
                factory.DefaultRequestHeaders.Add("X-TFS-FedAuthRedirect", "Suppress");
            });
  

            services.AddSingleton(setting);
            services.AddSession().AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<VisualStudioTeamServicesSettings>(x => Configuration.GetSection("VisualStudioTeamServices").Bind(x));
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSession();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
