using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Backend.App.Interface;
using Backend.App.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

//using de SWAGGER
using Microsoft.OpenApi.Models;

namespace Backend.App
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
            var key = "Demo Token ApiKey Exmaple";

            services.AddControllers();

            services
             .AddAuthentication(
             x =>
             {
                 x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             }
             )
             .AddJwtBearer(
              x =>
              {
                  x.RequireHttpsMetadata = false;
                  x.SaveToken = true;

                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                      ValidateAudience = false,
                      ValidateIssuerSigningKey = true,
                      ValidateIssuer = false
                  };

              }
              );


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Auth Demo - Curso de Sipecom S-A",
                    Description = "A simple demo with JWT Auth APIs and Basic Auth APIs",
                    Contact = new OpenApiContact
                    {
                        Name = @"GitHub Repository",
                        Email = "vidapogosoft@gmail.com",
                        Url = new Uri("https://github.com/vidapogosoft")
                    }
                });

                // add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });

                // add Basic Authentication
                var basicSecurityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    Reference = new OpenApiReference { Id = "BasicAuth", Type = ReferenceType.SecurityScheme }
                };
                c.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {basicSecurityScheme, new string[] { }}
                });
            });

            services.AddAuthorization();

            //Servicio verificador y creador de tokens JWT
            services.AddSingleton<IJwtAuthenticationService>(new JwtAuthenticationService(key));

            services.AddSingleton<IGetRegistrados, ServicesGetRegistrados>();
            services.AddSingleton<IPostRegistrados, ServicesPostRegistrados>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            ///uso del swagger -- ini
            app.UseSwagger();

            app.UseSwaggerUI(c =>

                  c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiBetaDocumentacion")

               );
            ///uso del swagger -- fin


            //llamo al middleware de la autenticacion
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
