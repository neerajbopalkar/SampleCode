using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopWebApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BethanysPieShopWebApp
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
            //** Add EF core
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );

            //** creates instance and maintains it for lifetime of http request
            //services.AddScoped<IPieRepository, MockPieRepository>();
            //services.AddScoped<ICategoryRepository, MockCategoryRepository>();

            //** commented mock repositories above and now using actual SQL repositoryies
            services.AddScoped<IPieRepository, SqlPieRepository>();
            services.AddScoped<ICategoryRepository, SqlCategoryRepository>();

            //when user first visits the site, check if user has CART available, if not create it.
            services.AddScoped<ShoppingCart>(serviceProvider => ShoppingCart.GetCart(serviceProvider));
            services.AddHttpContextAccessor();
            services.AddSession();

            //** returns new instance for every new injection request
            //services.AddTransient
            //** same instance for all requests
            //services.AddSingleton

            //** replaces services.AddMvc() in previous versions
            //** Adds services in DI container which comes out of the box. Services will be used throughout the application.
            //** can add - 1. built-in and 2. our own services

            //     Adds services for controllers to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
            //     This method will not register services used for pages.
            services.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //** add middleware components
            //** each component ALTERS the incoming request/outgoing response if required and passes it on to next component in pipeline
            //** each app.UseComponent call adds new component to pipeline
            //** ORDER in which they are added is IMPORTANT

            if (env.IsDevelopment())
            {
                //     Captures synchronous and asynchronous System.Exception instances from the pipeline
                //     and generates HTML error responses.
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //     Adds a middleware to the pipeline that will catch exceptions, log them, reset
                //     the request path, and re-execute the request. The request will not be re-executed
                //     if the response has already started.
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //     Adds middleware for using HSTS, which adds the Strict-Transport-Security header.
                app.UseHsts();
            }
            //     Adds middleware for redirecting HTTP Requests to HTTPS.
            app.UseHttpsRedirection();

            //     Enables static file serving for the current request path
            app.UseStaticFiles();

            //     Adds the Microsoft.AspNetCore.Session.SessionMiddleware to automatically enable
            //     session state for the application.
            // ** CALL it before UseRouting
            app.UseSession();

            //     Adds a Microsoft.AspNetCore.Routing.EndpointRoutingMiddleware middleware to the
            //     specified Microsoft.AspNetCore.Builder.IApplicationBuilder.
            app.UseRouting();

            //     Adds the Microsoft.AspNetCore.Authorization.AuthorizationMiddleware to the specified
            //     Microsoft.AspNetCore.Builder.IApplicationBuilder, which enables authorization
            //     capabilities.
            app.UseAuthorization();

           
            app.UseEndpoints(endpoints =>
            {
                //     Adds endpoints for controller actions to the Microsoft.AspNetCore.Routing.IEndpointRouteBuilder
                //     and specifies a route with the given name, pattern, defaults, constraints, and
                //     dataTokens.
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
