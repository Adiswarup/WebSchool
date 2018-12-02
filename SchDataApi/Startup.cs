using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SchDataApi.DataLayer;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;
//using TokenOptions = SchDataApi.Models.TokenOptions;

namespace SchDataApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SchContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("SchConnection")));

            services.AddCors(
            options => options.AddPolicy("AllowCors",
            builder =>
            {
                builder

                //.WithOrigins("http://hp:2829", "http://localhost:62602") //AllowSpecificOrigins;
                //.WithOrigins("http://localhost:4456", "http://localhost:4457") //AllowMultipleOrigins;
                .AllowAnyOrigin() //AllowAllOrigins;
                //.WithExposedHeaders("x-custom-header")
                //.WithMethods("GET") //AllowSpecificMethods;
                //.WithMethods("GET", "PUT") //AllowSpecificMethods;
                .AllowAnyMethod() //AllowAllMethods;

                //.WithHeaders("Accept", "Content-type", "Origin", "X-Custom-Header");  //AllowSpecificHeaders;
                .AllowAnyHeader(); //AllowAllHeaders;
            })
         );
            // Add framework services.
            //services.Configure<IISOptions>(options =>
            //{

            //}
            //   );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
           services.AddMvc();
 
            //services.AddAuthentication( /*o =>
            //    {
            //        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //        o.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            //    }*/ /*Uncomment this if you don't want to use JWT for all of your api*/)
            //    .AddJwtBearer(cfg =>
            //    {
            //        cfg.RequireHttpsMetadata = false;
            //        cfg.SaveToken = true;
            //        cfg.TokenValidationParameters = new TokenValidationParameters()
            //        {
            //            //ValidIssuer = Configuration["JwtIssuer"],
            //            ValidIssuer = Configuration["TokenOptions:Issuer"],
            //            ValidAudience = Configuration["TokenOptions:Issuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenOptions:Key"])),
            //        };
            //    });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Trusted", policy => policy.RequireRole("Admin"));
            //});
            //services.AddAuthorization(options => options.AddPolicy("Trusted", policy => policy.RequireClaim("Employee", "Mosalla")));

            services.AddOptions();

            //services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            app.UseCors("AllowCors");
            //app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = "swagger/ui";
            });
             app.UseMvc();
           //CreateRoles(serviceProvider);
        }

        //private void CreateRoles(IServiceProvider serviceProvider)
        //{

        //    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        //    Task<IdentityResult> roleResult;
        //    string email = "someone@somewhere.com";

        //    //Check that there is an Administrator role and create if not
        //    Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Administrator");
        //    hasAdminRole.Wait();

        //    if (!hasAdminRole.Result)
        //    {
        //        roleResult = roleManager.CreateAsync(new IdentityRole("Administrator"));
        //        roleResult.Wait();
        //    }

        //    //Check if the admin user exists and create it if not
        //    //Add to the Administrator role

        //    Task<AppUser> testUser = userManager.FindByEmailAsync(email);
        //    testUser.Wait();

        //    if (testUser.Result == null)
        //    {
        //        AppUser administrator = new AppUser
        //        {
        //            Email = email,
        //            UserName = email
        //        };

        //        Task<IdentityResult> newUser = userManager.CreateAsync(administrator, "_AStrongP@ssword!");
        //        newUser.Wait();

        //        if (newUser.Result.Succeeded)
        //        {
        //            Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, "Administrator");
        //            newUserRole.Wait();
        //        }
        //    }

        //}
    }
}
