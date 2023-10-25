using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Data;
using EPiServer.Find;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Nackademin23.Business.Extensions;
using Nackademin23.Business.Services;
using Nackademin23.Business.Services.Interfaces;
using Nackademin23.Business.TinyMce;
using Nackademin23.Models.Pages;
using Nackademin23.Models.Settings;

namespace Nackademin23
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;

        public Startup(IWebHostEnvironment webHostingEnvironment)
        {
            _webHostingEnvironment = webHostingEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_webHostingEnvironment.IsDevelopment())
            {
                AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

                services.Configure<SchedulerOptions>(options => options.Enabled = false);
            }
            services
                .AddCmsAspNetIdentity<ApplicationUser>()
                .AddCms()
                .AddFind()
                .AddNackademin()
                .AddAdminUserRegistration()
                .AddEmbeddedLocalization<Startup>()
                .TinyMceConfiguration();
                

            services.AddSingleton<IXmlSitemapService, XmlSitemapService>();

            services.Configure<FindOptions>(options =>
            {
                options.ServiceUrl = "https://demo04.find.episerver.net/2AeKxGXXSxIRIaoiFxErM77FgXg3yguO/";
                options.DefaultIndex = "patrikbyren_nackademin23";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "search",
                //    pattern: "search",
                //    defaults: new { controller = "SearchPage", action = "Index" });
                endpoints.MapContent();
            });
        }
    }
}