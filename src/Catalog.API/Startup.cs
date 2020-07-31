using Catalog.API.Extensions;
using Catalog.Domain.Extensions;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Catalog.API {
  public class Startup {
    public Startup (IConfiguration configuration) {
      Configuration = configuration;
    }

    private IConfiguration Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices (IServiceCollection services) {
      services
        .AddCatalogContext(
          Configuration.GetSection("DataSource:ConnectionString").Value
        )
        .AddScoped<IItemRepository, ItemRepository>()
        .AddMappers()
        .AddServices()
        .AddControllers()
        .AddValidation();
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      } else {
        app.UseHttpsRedirection();
      }
      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
