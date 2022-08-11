using ApplicationIdentity.Context;
using ApplicationIdentity.Implementations.Identity;
using ApplicationIdentity.Implementations.Repositories;
using ApplicationIdentity.Implementations.Services;
using ApplicationIdentity.Interfaces.Identity;
using ApplicationIdentity.Interfaces.Repositories;
using ApplicationIdentity.Interfaces.Services;
using ApplicationIdentity2.Implementations.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationIdentity
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
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationContext")));
            services.AddControllersWithViews();
            services.AddScoped<IUserRepository, UserStore>();
            services.AddScoped<IRoleRepository, RoleStore>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(config =>
               {
                   config.LoginPath = "/auth/login";
                   config.Cookie.Name = "DevLightAuth";
                   config.LogoutPath = "/auth/logout";
                   config.ExpireTimeSpan = TimeSpan.FromMinutes(2);
                   config.AccessDeniedPath = "/auth/login";
    
               });
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
