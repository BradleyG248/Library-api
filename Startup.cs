using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using library_api.Repositories;
using library_api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace library_api
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
      // Connection to DB
      services.AddScoped<IDbConnection>(x => CreateDbConnection());

      //Register Transients for Dependency Injection
      services.AddTransient<BooksService>();
      services.AddTransient<BooksRepository>();
      services.AddTransient<LibrariesService>();
      services.AddTransient<LibrariesRepository>();
      services.AddTransient<BookAuthorsService>();
      services.AddTransient<BookAuthorsRepository>();
      services.AddTransient<AuthorsService>();
      services.AddTransient<AuthorsRepository>();

    }

    private IDbConnection CreateDbConnection()
    {
      var connectionString = Configuration["db:gearhost"];
      return new MySqlConnection(connectionString);
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

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}