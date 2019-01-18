
using Application.DTOs;
using Application.IServices;
using Application.Services;
using Domain.IRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infraestructure.Persistencia;
using Infraestructure.Repositories;
using Infraestructure.Transversal.Authentication;
using Infraestructure.Transversal.FluentValidations;
using Infraestructure.Transversal.Swagger;
using iTrebolsoft.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using static Infraestructure.Transversal.Authentication.UserAuthService;

namespace iTrebolsoft
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
            services.AddDbContext<ItrebolsoftDbContext>(options =>
            options.UseSqlServer(Configuration["Data:Itrebolsoft:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options =>
           options.UseSqlServer(
           Configuration["Data:ItrebolsoftIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

            // REPOSITORIES
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<IBlogRepository, EFBlogRepository>();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IProyectoRepository, EFProyectoRepository>();
            services.AddTransient<IImageRepository, EFImageRepository>();

            // SERVICES
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IProyectoService, ProyectoService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IUserAuthService, UserAuthService>();

            // VALIDATORS
            services.AddTransient<IValidator<ProyectoDTO>, ProyectoDTOValidator>();
            services.AddTransient<IValidator<UserDTO>, UserDTOValidator>();

            // configure jwt authentication
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
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

            services.AddSwaggerGen(c => {
                var contacto = new Contact { Name = "Daniel I. Cabana", Email = "trebolman@gmail.com", Url = "itrebolsoft.com" };
                c.SwaggerDoc("v1", new Info { Title = "Itrebolsoft", Version = "v1" , Contact = contacto });

            });
            services.AddSwaggerDocumentation();
            services.AddMvc().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});

            app.UseSwaggerDocumentation();
            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
