using calisthenics_backend.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using calisthenics_backend.Repository;
using calisthenics_backend.Interface;
using calisthenics_backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace calisthenics_backend
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.Authority = "https://securetoken.google.com/AIzaSyB46gBisxgEnD9m6Wzz3jCYVLLTfeOfbMM";
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidIssuer = "https://securetoken.google.com/AIzaSyB46gBisxgEnD9m6Wzz3jCYVLLTfeOfbMM",
						ValidateAudience = true,
						ValidAudience = "AIzaSyB46gBisxgEnD9m6Wzz3jCYVLLTfeOfbMM",
						ValidateLifetime = true
					};
				});

			services.AddControllers().AddNewtonsoftJson(options =>
					options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "calisthenics_backend", Version = "v1" });
			});

			services.AddDbContext<Context>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));

			services.AddScoped<IRepository<ForumMember>, ForumMemberRepository>();
			services.AddScoped<IRepository<CommunityMember>, CommunityMemberRepository>();
			services.AddScoped<IRepository<ForumCategory>, ForumCategoryRepository>();
			services.AddScoped<IRepository<ForumPost>, ForumPostRepository>();
			services.AddScoped<IRepository<ForumComment>, ForumCommentRepository>();
			services.AddScoped<IRepository<Workout>, WorkoutRepository>();
			services.AddScoped<IRepository<WorkoutLocation>, WorkoutLocationRepository>();
			services.AddScoped<IRepository<WorkoutType>, WorkoutTypeRepository>();

			services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
								  builder =>
								  {
									  builder.AllowAnyOrigin();
									  builder.AllowAnyHeader();
									  builder.AllowAnyMethod();
								  });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "calisthenics_backend v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(MyAllowSpecificOrigins);

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
