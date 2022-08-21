using System.Text;
using Application.AuthUseCases;
using Application.RecordUseCases;
using Application.UserUseCases;
using Domain.Repositories;
using Domain.Services;
using JwtAuthentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoRepository.RecordRepro;
using MongoRepository.Settings;
using MongoRepository.UserRepo;

namespace API
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
            this.ConfigureDB(services);   
            this.ConfigureUseCases(services);
            this.ConfigureDomain(services);
            this.ConfigureJwtAuthentication(services);

            services.AddControllers();
        }

        public void ConfigureDB(IServiceCollection services)
        {
            services.Configure<UserMongoSettings>(Configuration.GetSection(nameof(UserMongoSettings)));
            services.AddSingleton<IMongoRepositorySettings<UserModel>, UserMongoSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<UserMongoSettings>>().Value);
        
            services.Configure<RecordMongoSettings>(Configuration.GetSection(nameof(UserMongoSettings)));
            services.AddSingleton<IMongoRepositorySettings<RecordModel>, RecordMongoSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<RecordMongoSettings>>().Value);
        }
        public void ConfigureUseCases(IServiceCollection services)
        {
            services.AddSingleton<Login>();

            services.AddSingleton<CreateRecord>();
            services.AddSingleton<GetRecord>();
            services.AddSingleton<ListAllRecords>();
            services.AddSingleton<SumAllRecords>();

            services.AddSingleton<CreateUser>();
            services.AddSingleton<GetUser>();
            services.AddSingleton<ListAllUsers>();
            services.AddSingleton<ListUserRecords>();
            services.AddSingleton<SumUserRecords>();
        }
        public void ConfigureDomain(IServiceCollection services)
        {
            services.AddSingleton<CheckUserAlreadyExists>();
            services.AddSingleton<IUserRepository, UserMongoRepository>();
            services.AddSingleton<IRecordRepository, RecordMongoRepository>();
            services.AddSingleton<RecordFinder>();
            services.AddSingleton<SumRecords>();
            services.AddSingleton<UserFinder>();
        }
        public void ConfigureJwtAuthentication(IServiceCollection services)
        {
            services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"])
                        )
                    };
                }
            );
        
            services.Configure<JwtConfiguration>(Configuration.GetSection("JWT"));
            services.AddSingleton<JwtConfiguration>(serviceProvider => serviceProvider.GetRequiredService<IOptions<JwtConfiguration>>().Value);
            services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
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
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
