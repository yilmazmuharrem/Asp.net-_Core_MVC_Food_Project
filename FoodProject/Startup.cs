using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
namespace FoodProject
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
            services.AddRazorPages();
            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                });


            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                   .RequireAuthenticatedUser()
                   .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder().
            //    RequireAuthenticatedUser().
            //    Build();

            //    config.Filters.Add(AuthorizeFilter(policy));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {




            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //sýrasýna dikkat ediyoruz..

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Category}/{action=Index}/{id?}");

            });

            //  app.UseStaticFiles();
            ////  app.UseRouting();
            //  app.UseCors();

            //  app.UseAuthentication();
            //  app.UseRouting();
            //  app.UseAuthorization();



            //  app.UseEndpoints(endpoints =>
            //  {
            //      endpoints.MapControllerRoute("default", "{controller=Food}/{action=Index}/{id?}");
            //  });



            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});









            //   if (env.IsDevelopment())
            //   {
            //       app.UseDeveloperExceptionPage();
            //   }
            //   else
            //   {
            //       app.UseExceptionHandler("/Error");
            //       // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //       app.UseHsts();
            //   }

            //   app.UseHttpsRedirection();
            //   app.UseStaticFiles();

            ////   app.UseRouting();

            //   app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            //   {
            //       endpoints.MapRazorPages();
            //   });

            //   app.UseEndpoints(endpoints =>
            //   {
            //       endpoints.MapControllerRoute("default", "{controller=Food}/{action=Index}");
            //   });

            //app.UseMvc(routes =>
            //{
            //   routes.MapRoute(
            //       name: "default",
            //       template: "{controller=Category}/{action=Index}/{id?}");
            //});
        }
    }
}
