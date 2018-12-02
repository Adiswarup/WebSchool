using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using WebCat7.Auth;
using WebCat7.Data;
using WebCat7.Extensions;
using WebCat7.Models;
using WebCat7.Services;
using TokenOptions = WebCat7.Models.TokenOptions;
using Syncfusion.Licensing;

namespace WebCat7
{
    public class Startup
    {
        private IHostingEnvironment _hostingEnv;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();

            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            _hostingEnv = env;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<SchContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SchConnection")));
            //services.AddCors(
            //        options => options.AddPolicy("AllowCors",
            //        builder =>
            //            {
            //                builder
            //                .WithOrigins("http://HP:7451") //AllowSpecificOrigins;
            //                //.WithOrigins("http://localhost:4456", "http://localhost:4457") //AllowMultipleOrigins;
            //                //.AllowAnyOrigin() //AllowAllOrigins;

            //                //.WithMethods("GET") //AllowSpecificMethods;
            //                .WithMethods("GET", "PUT") //AllowSpecificMethods;
            //                //.AllowAnyMethod() //AllowAllMethods;

            //                .WithHeaders("Accept", "Content-type", "Origin", "X-Custom-Header");  //AllowSpecificHeaders;
            //                //.AllowAnyHeader(); //AllowAllHeaders;
            //            })
            //        );

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                // Signin settings
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<Microsoft.AspNetCore.Identity.IUserClaimsPrincipalFactory<AppUser>, AppClaimsPrincipalFactory>();
            services.AddAuthentication( /*o =>

                {

                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                    o.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;

                }*/ /*Uncomment this if you don't want to use JWT for all of your api*/

                 //.AddJwtBearer(cfg =>

                 //{
                 //    cfg.RequireHttpsMetadata = false;
                 //    cfg.SaveToken = true;
                 //    cfg.TokenValidationParameters = new TokenValidationParameters()
                 //    {
                 //        ValidIssuer = Configuration["TokenOptions:Issuer"],
                 //        ValidAudience = Configuration["TokenOptions:Issuer"],
                 //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenOptions:Key"])),
                 //    };
                 //}
                 );

            services.Configure<IdentityOptions>(options =>
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@31362e332e30CBt5vXGMRIPX9j/P3+QVtzrgOtk1IZOdnCsHASqsfhQ=");
                //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("OTM5N0AzMTM2MmUzMjJlMzBjM01MTDVrVzd1TTRqeFdNa3gveEpPSXFSWHp2ZU1mNFlPQ1Mwb2xCbzJRPQ==");
                //@31362e332e30CBt5vXGMRIPX9j/P3+QVtzrgOtk1IZOdnCsHASqsfhQ=


                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;
                //options.User.RequireUniqueEmail = true;
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;
                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.Name = "WebCat";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(600);
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to / Account / Login
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to / Account / Logout
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to / Account / AccessDenied
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            });

            services.AddMvc(options =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                    //set global format to xml
                    options.Filters.Add(new ProducesAttribute("application/json"));
                    options.Filters.Add(new AuthorizeFilter(policy));
                })
            .AddJsonOptions(options =>
            {
                // JSON serialization not defaulting to default?
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            #region snippet_SSL 
            //var skipSSL = Configuration.GetValue<bool>("LocalTest:skipSSL");
            //requires using Microsoft.AspNetCore.Mvc;
            //services.Configure<MvcOptions>(options =>
            //{
            //    // Set LocalTest:skipSSL to true to skip SSL requrement in 
            //    // debug mode. This is useful when not using Visual Studio.
            //    if (_hostingEnv.IsDevelopment() && !skipSSL)
            //    {
            //        options.Filters.Add(new RequireHttpsAttribute());
            //    }
            //});
            #endregion
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("SubTeacherRole", policy => policy.RequireClaim("SubTeacher"));
            });

            services.AddOptions();
            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            services.AddSingleton<IAuthorizationHandler, SubTeacherHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IServiceProvider serviceProvider)
        //RoleManager<IdentityRole<int>> roleManager)
        {
            //string mEss = "";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("OTM5N0AzMTM2MmUzMjJlMzBjM01MTDVrVzd1TTRqeFdNa3gveEpPSXFSWHp2ZU1mNFlPQ1Mwb2xCbzJRPQ==");
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@31362e322e30Bhvbq/Auhpm7d1LvRe56syHqftovxEYkELGykdBggnY=");
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            //Syncfusion.Licensing.SyncfusionLicenseProvider.ValidateLicense(Syncfusion.Licensing.Platform.ASPNETCore,out mEss);
            //Console.Write(mEss);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCors("AllowCors");
            //app.UseIdentity();
            app.UseAuthentication();

            //ConfigureAuth(app);
            //createRolesandUsers();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            //if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")))
            //{
            //    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"js", @"ej2")))
            //    {
            //        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"js", @"ej2"));
            //        File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"scripts", @"ej2.min.js"), Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"js", @"ej2", @"ej2.min.js"));
            //    }

            //    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2")))
            //    {
            //        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2"));
            //        File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"styles", @"bootstrap.css"), Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2", @"bootstrap.css"));
            //        File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"styles", @"material.css"), Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2", @"material.css"));
            //        File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"styles", @"highcontrast.css"), Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2", @"highcontrast.css"));
            //        File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"styles", @"fabric.css"), Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2", @"fabric.css"));
            //    }
            //}
        }

    }
}
