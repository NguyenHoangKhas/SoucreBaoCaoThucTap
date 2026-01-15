using _365EJSC.ERP.Contract.Constants;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Auth;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Base;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.University;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.HRM;
using _365EJSC.ERP.Persistence.Repositories.Auth;
using _365EJSC.ERP.Persistence.Repositories.Base;
using _365EJSC.ERP.Persistence.Repositories.Define;
using _365EJSC.ERP.Persistence.Repositories.HRM;
using _365EJSC.ERP.Persistence.Repositories.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _365EJSC.ERP.Persistence.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register infrastructure EF services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Application configuration</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString(Const.CONN_CONFIG_SQL);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.RegisterServices();
            return services;
        }

        /// <summary>
        /// Registering infrastructure ef services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericSqlRepository<,>), typeof(GenericSqlRepository<,>));
            services.AddScoped<ISqlUnitOfWork, SqlUnitOfWork>();

            #region Define

            services.AddScoped<IConfigIconSqlRepository, ConfigIconSqlRepository>();

            #endregion

            #region HRM

            services.AddScoped<IBankSqlRepository, BankSqlRepository>();
            services.AddScoped<IContractTypeSqlRepository, ContractTypeSqlRepository>();
            services.AddScoped<IDegreeSqlRepository, DegreeSqlRepository>();
            services.AddScoped<IEmployeeSqlRepository, EmployeeSqlRepository>();
            services.AddScoped<IEmployeeVerifySqlRepository, EmployeeVerifySqlRepository>();
            services.AddScoped<IEmployeeRoleSqlRepository, EmployeeRoleSqlRepository>();
            services.AddScoped<IEmployeeCompanySqlRepository, EmployeeCompanySqlRepository>();
            services.AddScoped<IHrmAttendanceSqlRepository, AttendanceSqlRepository>();
            services.AddScoped<IHelpdeskCatalogSqlRepository, HelpdeskCatalogSqlRepository>();
            services.AddScoped<IHelpdeskContentSqlRepository, HelpdeskContentSqlRepository>();
            services.AddScoped<IHrmAttendanceHisSqlRepository, AttendanceHisSqlRepository>();
            #endregion

            #region University
            services.AddScoped<IUserSqlRepository, UserSqlRepository>();
            services.AddScoped<ILecturerSubjectSqlRepository, LecturerSubjectSqlRepository>();
            services.AddScoped<ISubjectSqlRepository, SubjectSqlRepository>();
            services.AddScoped<IStudentSqlRepository, StudentSqlRepository>();
            services.AddScoped<IClassSqlRepository, ClassSqlRepository>();
            services.AddScoped<ICourseRegistrationSqlRepository, CourseRegistrationSqlRepository>();
            services.AddScoped<ILecturerSqlRepository, LecturerSqlRepository>();
            services.AddScoped<IGradeSqlRepository, GradeSqlRepository>();
            #endregion
            return services;
        }
    }
}
