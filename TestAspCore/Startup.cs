using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAspCore.Authentication;
using TestAspCore.Models;
using TestAspCore.IServices;
using TestAspCore.Services;

namespace TestAspCore
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

            services.AddControllers();
            //For Entity Framework
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConStr")));

            //For Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
           services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin",x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


            // testing controller
           
            services.AddHttpClient();
            /* services.AddDbContext<testdbContext>(options =>
             options.UseSqlServer(Configuration["DbConnection"]));*/
            services.AddDbContext<testdbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConStr")));
          
        
            services.AddTransient<IUserList, UserList>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IIssuesService, IssuesService>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<ITestVideoService, TestVideoService>();
            services.AddTransient<ISessionVideoService, SessionVideoService>();
            //Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           

            //Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT:Secret"])),
                    
                    
                };
            });

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v3", new OpenApiInfo { Title = "SeleniumBackEnd", Version = "v3" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v3/swagger.json", "SeleniumBackEnd v3"));
            }

            app.UseRouting();
            app.UseCors("AllowOrigin");
            //Authentication comes before Authorization.
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        

        }
    }
}
