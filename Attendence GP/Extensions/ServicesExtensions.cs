using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;
using Domain.Models;
using Contracts.ServicesContracts;
using Microsoft.OpenApi.Models;

namespace Attendence_GP.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });
            });

        public static void ConfigureIISintegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });

        public static void ConfigureSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Attendance", Version = "v1" });
            });

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ITIAttendanceContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("hKConn"),
                builder => builder.MigrationsAssembly(assemblyName: typeof(Program).Assembly.GetName().Name)));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IAppRepositoryManager, AppRepositoryManager>();

        public static void ConfigureServicesManager(this IServiceCollection services) =>
            services.AddScoped<IServicesManager, ServicesManager>(); 
       



        //public static void ConfigureIdentity(this IServiceCollection services)
        //{
        //    var builder = services.AddIdentityCore<User>(us =>
        //    {
        //        us.Password.RequireDigit = true;
        //        us.Password.RequireLowercase = false;
        //        us.Password.RequireUppercase = false;
        //        us.Password.RequireNonAlphanumeric = false;
        //        us.Password.RequiredLength = 10;
        //        us.User.RequireUniqueEmail = true;
        //    });
        //    builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
        //    builder.AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();
        //}

        //public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        //{
        //    //issuer: server that create the token
        //    //audeince: the reciever of the token
        //    var jwtSettings = configuration.GetSection("JWTSettings");
        //    var secretKey = "123456";//Environment.GetEnvironmentVariable("Secret");
        //    services.AddAuthentication(opt =>
        //    {
        //        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    }).AddJwtBearer(options =>
        //    {
        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = "Mine",
        //            ValidAudience = "https://localhost:44333;http://localhost:5000",
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        //        };
        //    });
        //}
    }
}
