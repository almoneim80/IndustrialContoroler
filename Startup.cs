using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;

namespace IndustrialContoroler
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            //services.Configure<RazorViewEngineOptions>(options =>
            //{
            //    options.ViewLocationExpanders.Add(new MyViewLocationExpander());
            //});
        }
    }
}
