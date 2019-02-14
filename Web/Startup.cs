using ExperianTest.ApplicationCore;
using ExperianTest.ApplicationCore.Entities;
using ExperianTest.ApplicationCore.Interfaces;
using ExperianTest.ApplicationCore.Services;
using ExperianTest.ApplicationCore.Validators;
using ExperianTest.Persistence.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExperianTest.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                             .AddRazorPagesOptions(options =>
                             {
                                 options.Conventions.AddPageRoute("/Products/CardSearch", "");
                                 options.Conventions.AddPageRoute("/Products/CardSearch", "/Products/");
                                 options.Conventions.AddPageRoute("/Products/CardSearch", "/CardSearch/");
                                 //options.Conventions.AddPageRoute("/Products/CardResults", "/CardResults/");
                                 //options.Conventions.AddPageRoute("/Products/CardSearch", "/Products/CardResults/");
                             });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddScoped(typeof(IAsyncRepository<Product>), typeof(ProductRepository));
            services.AddScoped<IRequestRepository, RequestRepository>();

            services.AddScoped<ICustomerValidator, CustomerValidator>();

            // uncomment to apply hardcoded rules
            //services.AddScoped<IProductResultsValidator, ProductResultsValidator>();

            // uses rules stored in database
            services.AddScoped<IProductResultsValidator, ProductRulesValidator>();

            services.AddScoped<ICustomerDetailsFormatter, CustomerDetailsFormatter>();

            services.AddScoped<IProductSearchService, ProductSearchService>();
            services.AddScoped<IProductSearchResultService, ProductSearchResultService>();

            string connectionString = Configuration.GetConnectionString("CardSearchDatabase");
            services.AddDbContext<CardSearchDbContext>(options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
