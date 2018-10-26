using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocuco.Application.Services.OcucoHub.CatalogueService;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoAuditService;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService;
using Ocuco.Application.Services.OcucoHub.MailService;
using Ocuco.DataModel.Catalog.Context;
using Ocuco.DataModel.Hydradb.Context;
using Ocuco.DataModel.Hydradb.Repository;
using Ocuco.DataModel.Hydradb.SeedDB;
using Ocuco.DataModel.Hydradbsecurity.Context;
using Ocuco.DataModel.Hydradbsecurity.Entities;
using Ocuco.DataModel.Hydradbsecurity.SeedDB;
using Ocuco.Domain.Persistence.Repositories.Catalog;
using Ocuco.Domain.Persistence.Repositories.Rxo;
using Swashbuckle.AspNetCore.Swagger;

namespace Ocuco.Hydra.WebMVC21.V2
{
    public class Startup
    {
        private readonly IConfiguration config;


        public Startup(IConfiguration config)
        {
            this.config = config;
        }




        

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ///////////////////////////////////
            //
            // Identity
            //
            ///////////////////////////////////

            services.AddIdentity<HubUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<HydraSecurityContext>();



            ///////////////////////////////////
            //
            // DbContexts
            //
            ///////////////////////////////////

            services.AddDbContext<hydradbcatalogContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("HydraCatalogConnectionString"));
            });

            services.AddDbContext<HydraContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("HydraConnectionString"),
                    sqlServerOptions =>
                    {
                        sqlServerOptions.MigrationsAssembly("Ocuco.DataModel.Hydradb");
                    });
            });

            services.AddDbContext<HydraSecurityContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("HydraSecurityConnectionString"),
                    sqlServerOptions =>
                    {
                        sqlServerOptions.MigrationsAssembly("Ocuco.DataModel.Hydradbsecurity");
                    });
            });



            ///////////////////////////////////
            //
            // Automapper
            //
            ///////////////////////////////////

            services.AddAutoMapper();



            /////////////////////////////////////////
            //
            // Application Services (Transient)
            //
            /////////////////////////////////////////

            services.AddTransient<IMailService, NullMailService>();
            //services.AddTransient<IMailService, SmtpClientMailService>();
            
            services.AddTransient<HydraSeeder>();
            services.AddTransient<HydradbsecuritySeeder>();



            /////////////////////////////////////////
            //
            // Repositories
            //
            /////////////////////////////////////////

            services.AddScoped<ISampleRepository, SampleRepository>();
            services.AddScoped<IRxoRepository, RxoRepository>();
            services.AddScoped<ICatalogueRepository, CatalogueRepository>();



            /////////////////////////////////////////////
            //
            // Application Services (Scoped)
            //
            /////////////////////////////////////////////

            services.AddScoped<ILuxotticaRxoService, LuxotticaRxoService>();
            services.AddScoped <ILuxotticaRxoAuditService, LuxotticaRxoAuditService>();
            services.AddScoped<ICatalogueService, CatalogueService>();



            /////////////////////////////////////////////
            //
            // CORS
            //
            /////////////////////////////////////////////

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });


            
            /////////////////////////////////////////////
            //
            // MVC
            //
            /////////////////////////////////////////////

            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                ;

            // options.SerializerSettings.ContractResolver = new DefaultContractResolver()




            /////////////////////////////////////////////
            //
            // Versioning
            //
            /////////////////////////////////////////////

            //services.AddApiVersioning(o => o.ApiVersionReader = new HeaderApiVersionReader("1.0"));
            //services.AddApiVersioning(o => {
            //    o.ReportApiVersions = true;
            //    o.AssumeDefaultVersionWhenUnspecified = true;
            //    o.DefaultApiVersion = new ApiVersion(1, 0);
            //});
            //services.AddApiVersioning(o => {
            //    o.AssumeDefaultVersionWhenUnspecified = true;
            //    o.DefaultApiVersion = new ApiVersion(new DateTime(2016, 7, 1));
            //});


            /////////////////////////////////////////////
            //
            // Swagger
            //
            /////////////////////////////////////////////

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Hydra APIs", Version = "v1" });
            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "ToDo API",
            //        Description = "A simple example ASP.NET Core Web API",
            //        TermsOfService = "None",
            //        Contact = new Contact
            //        {
            //            Name = "Cosmos Team",
            //            Email = string.Empty,
            //            Url = "https://twitter.com/spboyer"
            //        },
            //        License = new License
            //        {
            //            Name = "Use under LICX",
            //            Url = "https://example.com/license"
            //        }
            //    });
            //});


            services.AddHttpClient();
        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //options.SwaggerEndpoint("/swagger/Catalogue/swagger.json", "Catalogue");
            });



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // If you need to run something in Dev
                //using (var scope = app.ApplicationServices.CreateScope())
                //{
                //    var seeder = scope.ServiceProvider.GetService<HydradbsecuritySeeder>();
                //    seeder.SeedAsync().Wait();
                //}
            }
            else
            {
                app.UseExceptionHandler("/error");
            }



            // write text 
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hydra");
            //});

            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseNodeModules(env);



            app.UseAuthentication();



            app.UseCors("AllowAll");



            app.UseMvc(cfg =>
            {
                cfg.MapRoute(
                    "Foo",
                    "{controller}/{action}/{id?}",
                    new { controller = "App", Action = "Index" });
            });
        }
    }
}
