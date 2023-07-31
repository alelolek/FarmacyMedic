using FarmacyMedic.Models.Mapping;
using FarmacyMedic.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace FarmacyMedic
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			services.AddDbContext<FarmacyDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("Connection"));
			});
			services.AddAutoMapper(
							typeof(ProductMapperProfile),
                            typeof(ClientMapperProfile),
							typeof(OrderMapperProfile),
							 typeof(InvoiceMapperProfile)
                            );
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}	
