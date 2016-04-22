using System;
using System.IO;
using ManagerReports.Dal;
using ManagerReports.Services.Interfaces;
using ManagerReports.Services.Interfaces.Reports;
using ManagerReports.Services.Services;
using ManagerReports.Services.Services.Reports;
using ManagerReports.Web.Controllers;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ManagerReports.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"config{env.EnvironmentName}.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        private IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<ITimeRecordService, TimeRecordService>();

            services.AddTransient<IProjectReportService, ProjectReportService>();
            services.AddTransient<IEmployeeReportService, EmployeeReportService>();
            services.AddTransient<IProjectExcelReportService, ProjectExcelReportService>();
            services.AddTransient<IEmployeeExcelReportService, EmployeeExcelReportService>();

            services.AddTransient<ManagerReportsContext>();
            services.AddInstance(Configuration);

            services.AddCaching();
            services.AddSession();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.RollingFile(Path.Combine(env.WebRootPath, "logs", "{Date}.log"))
                .CreateLogger();

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseCookieAuthentication(options =>
            {
                options.AuthenticationScheme = "Cookies";
                options.LoginPath = new PathString($"/{AccountController.Name}/{AccountController.LoginAction}/");
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: $"{{controller={HomeController.Name}}}/{{action={HomeController.DefaultAction}}}/{{id?}}"
                    );
            });

            loggerFactory.AddSerilog();

            SeedData.Initialize(app.ApplicationServices);
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}