using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace senai.gufi.webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()

                .AddNewtonsoftJson(options => 
                {
                    // Ignora loops infinitos
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    // Ignora valores nulos
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services
                .AddAuthentication(options => 
                {
                    options.DefaultAuthenticateScheme   = "JwtBearer";
                    options.DefaultChallengeScheme      = "JwtBearer";
                })

                .AddJwtBearer("JwtBearer", options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // define que o issuer ser� validado
                        ValidateIssuer = true,

                        // define que o audience ser� validado
                        ValidateAudience = true,

                        // define que o tempo de vida ser� validado
                        ValidateLifetime = true,

                        // forma de criptografia e a chave de autentica��o
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao")),

                        // verifica o tempo de expira��o do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // define o nome da issuer, de onde est� vindo
                        ValidIssuer = "gufi.webApi",

                        // define o nome da audience, para onde est� indo
                        ValidAudience = "gufi.webApi"
                    };
                });

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1", new OpenApiInfo { Version = "V1", Title = "gufi.webApi", Description = "API para gerenciar eventos de uma escola t�cnica"});

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
               
            // Adiciona o CORS ao projeto
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => {
                        builder.WithOrigins("http://localhost:3000")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod();
                    }

                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "gufi.webApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();

            app.UseAuthorization();

            // Habilita o CORS
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
