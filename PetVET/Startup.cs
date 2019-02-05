using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetVET.Data;
using PetVET.Models;
using PetVET.Services;
using AutoMapper;
using PetVET.Database.Models;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using PetVET.Repository;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Web.Http.Filters;
using PetVET.Repository.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PetVET.Extentions;
using PetVET.Infrastructure;
using PetVET.Infrastructure.ErrorHandling;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PetVET.Models.Mail;
using PetVET.Services.User;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace PetVET
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

            services.AddDbContext<PetVetDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PetVETDbConnection")))
             ;//.AddUnitOfWork<GrommerContext>();
            services.AddAutoMapper();
            services.AddMvc();


            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                //Ustawinie ile czasu ma byc blokowany user jezeli wpsze zle haslo
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(5);
                //options.Lockout.MaxFailedAccessAttempts = 5;

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<Microsoft.AspNetCore.Identity.IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "http://localhost:44343/",
                        ValidAudience = "http://localhost:44343/",
                        IssuerSigningKey = new SymmetricSecurityKey(key),

                        //ValidIssuer = Configuration["Tokens:Issuer"],
                        //ValidAudience = Configuration["Tokens:Issuer"],
                        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))


                    };
                });

            //services.AddAuthentication(option =>
            //{
            //    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            //}).AddCookie();
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
            services.AddTransient<DbContext, PetVetDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICreateOrganization, CreateOrganization>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<IApplicationUserAccesor, ApplicationUserAccesor>();            
            services.AddTransient<IUserOperation, UserOperation>();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddScoped<ModelStateValidationFilter>();
            services.AddTransient(typeof(IStoreProcedureParser<>), typeof(StoreProcedureParser<>));
            services.AddTransient(typeof(IEntityCommandService<,,>), typeof(EntityCommandService<,,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

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

            app.UseAuthentication();    
             app.ConfigureCustomExceptionMiddleware();


            //  app.UseSession();

            //app.UseCors(x => x.Build().Origins.Add(
            //);
            //    //.AllowAnyOrigin()
            //    //.AllowAnyMethod()
            //    //.AllowAnyHeader());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            CreateUserRoles(services).Wait();

        }

        private async Task CreateUserRoles(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                        

            var roleCheck = await roleManager.RoleExistsAsync("Manager");
            if (!roleCheck)
                await roleManager.CreateAsync(new IdentityRole("Manager"));

            roleCheck = await roleManager.RoleExistsAsync("Weterynarz");
            if (!roleCheck)
                await roleManager.CreateAsync(new IdentityRole("Weterynarz"));

            roleCheck = await roleManager.RoleExistsAsync("Recepcja");
            if (!roleCheck)
                await roleManager.CreateAsync(new IdentityRole("Recepcja"));


            roleCheck = await roleManager.RoleExistsAsync("SuperAdmin");
            if (!roleCheck)
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));

            
            var mail = "petvet@gmail.com";
            var user = await UserManager.FindByEmailAsync(mail);

            if (user == null)
            {
                int LastOrganizatioId = UserManager.Users.ToList().Max(x => x.OrganizationId);
                user = new ApplicationUser { Email = mail, UserName = mail};
                var result = await UserManager.CreateAsync(user, "Haslo1!");
                
                if (result.Succeeded)
                {
                    user = await UserManager.FindByEmailAsync(mail);
                    await UserManager.AddToRoleAsync(user, "SuperAdmin");
                }

            }
        }
    }
}
