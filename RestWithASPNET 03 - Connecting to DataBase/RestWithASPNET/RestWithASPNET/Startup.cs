using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET
{
    public class Startup
    {
        //Construtor da classe
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Conecting to database
            var connection = Configuration.GetConnectionString("MySqlConnectionString");
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));

            //Add framework servives.
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddMvc();

            //Dependecy Injection
            services.AddScoped<IPersonService, PersonsServiceImplementation>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
