using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InterLab.API.Domain.IRepositories;
using InterLab.API.Domain.Services;
using InterLab.API.Domain.Repositories;
using InterLab.API.Domain.Persistence.Contexts;
using InterLab.API.Persistence.Repositories;
using InterLab.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.OpenApi.Models;
using InterLab.API.Settings;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace InterLab.API
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

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //JWT Authentication Configuration 

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();

            services.AddScoped<IInternshipService, InternshipService>();
            services.AddScoped<IInternshipRepository, InternshipRepository>();

            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProfileService, ProfileService>();
;
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<IQualificationService, QualificationService>();

            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRequestService, RequestService>();

            services.AddScoped<IRequirementRepository, RequirementRepository>();
            services.AddScoped<IRequirementService, RequirementService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserCompanyRepository, UserCompanyRepository>();
            services.AddScoped<IUserCompanyService, UserCompanyService>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InterLab API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthorization();
            app.UseAuthentication();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InterLab API V1");
            });
        }
    }
}
