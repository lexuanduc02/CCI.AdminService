using CCI.Service;
using CCI.Service.Contractors;

namespace CCIAdmin.ModuleRegistrations
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {
            return services
                    .AddScoped<IEmailService, EmailService>()
                    .AddScoped<IDepartmentService, DepartmentService>()
                    .AddScoped<ICompanyService, CompanyService>()
                    .AddScoped<IJobPostService, JobPostService>()
                    .AddScoped<IUserDepartmentService, UserDepartmentService>()
                    .AddScoped<IRequirementService, RequirementService>()
                    .AddScoped<IUserService, UserService>()
                ;
        }
    }
}
