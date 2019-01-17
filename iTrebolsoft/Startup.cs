﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.IServices;
using Application.Services;
using Domain;
using Domain.IRepositories;
using Infraestructure.Repositories;
using iTrebolsoft.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

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

            // SERVICES
            services.AddTransient<IUserService, UserService>();

            // 

            services.AddSwaggerGen(c => {
                var contacto = new Contact { Name = "Daniel I. Cabana", Email = "trebolman@gmail.com", Url = "itrebolsoft.com" };
                c.SwaggerDoc("v1", new Info { Title = "Itrebolsoft", Version = "v1" , Contact = contacto });

            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
