using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetVetNew.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetVET.Infrastructure.ErrorHandling;
using System.IO;
using Microsoft.Extensions.FileProviders;
using PetVET.Extentions;
using Microsoft.AspNetCore.Identity.UI.Services;
using PetVET.Services;
using PetVET.Repository;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PetVET.Database.Models;
using PetVET.Models.Mail;
using PetVET.Infrastructure;
using PetVET.Services.User;
using System.Web.Http.Filters;
using PetVET.Repository.Core;
using Microsoft.IdentityModel.Tokens;
using JwtAuthenticationHelper.Extensions;
using PetVET.Models;
using System.Text;
using AutoMapper;
using TokenManager.Api.Services;


namespace PetVetNew
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddDbContext<DBVETContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PetVETDbConnection")));
          // ;//.AddUnitOfWork<GrommerContext>();
            services.AddAutoMapper();


            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);




            var validationParams = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,

                ValidateAudience = true,
                //ValidAudience = Configuration["Token:Audience"],
                ValidAudience = "http://localhost:44330/",

                ValidateIssuer = true,
                // ValidIssuer = Configuration["Token:Issuer"],
                ValidIssuer = "http://localhost:44330/",

                // IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Token:SigningKey"])),
                IssuerSigningKey = new SymmetricSecurityKey(key),
                
                ValidateIssuerSigningKey = true,
                
                RequireExpirationTime = true,
                ValidateLifetime = true
            };

     





            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddJwtAuthenticationWithProtectedCookie(validationParams);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequiresAdmin", policy => policy.RequireClaim("HasAdminRights"));
            });
            

            services.AddTransient<TokenManagerMiddleware>();
            services.AddTransient<PetVET.Services.IEmailSender, EmailSender>();
            services.AddTransient<DbContext, DBVETContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICreateOrganization, CreateOrganization>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<IApplicationUserAccesor, ApplicationUserAccesor>();
            services.AddTransient<IUserOperation, UserOperation>();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddScoped<ModelStateValidationFilter>();
            services.AddTransient(typeof(IStoreProcedureParser<>), typeof(StoreProcedureParser<>));

            
          //  services.AddTransient(typeof(IEntityCommandService<,,>), typeof(EntityCommandService<,,>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

      
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            if (env.IsDevelopment())
            {
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(
                      Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                    RequestPath = new PathString("/vendor")
                });
            }



            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (!serviceScope.ServiceProvider.GetService<ApplicationDbContext>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
                    //serviceScope.ServiceProvider.GetService<GrommerContext>().EnsureSeeded();
                }
            }


            app.ConfigureCustomExceptionMiddleware();
            app.UseMiddleware<TokenManagerMiddleware>();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
