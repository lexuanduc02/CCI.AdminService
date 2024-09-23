using CCI.Domain;
using CCI.Model;
using CCI.Repository;
using CCI.Repository.Contractors;
using Microsoft.EntityFrameworkCore;

namespace CCIAdmin.ModuleRegistrations
{
    public static class RepositoryCollection
    {
        public static IServiceCollection AddRepositoryCollection(this IServiceCollection services,
            ConnectionStringModel connectionStrings)
        {
            services.AddDbContext<DataContext>(option => option.UseNpgsql(connectionStrings.Default))
                    .AddDbContext<IdentityContext>(option => option.UseNpgsql(connectionStrings.Identity))
                ;

            return services
                    .AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddScoped<IDepartmentRepository, DepartmentRepository>()
                    .AddScoped<ICompanyRepository, CompanyRepository>()
                    .AddScoped<IJobPostRepository, JobPostRepository>()
                    .AddScoped<IUserDepartmentRepository, UserDepartmentRepository>()
                    .AddScoped<IRequirementRepository, RequirementRepository>()
                    .AddScoped<IUserRepository, UserRepository>()
                ;
        }
    }
}
