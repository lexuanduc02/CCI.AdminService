using CCI.Model.Options;

namespace CCIAdmin.ModuleRegistrations
{
    public static class OptionCollection
    {
        public static IServiceCollection AddOptionCollection(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                    .Configure<LogOption>(option => configuration.GetSection(LogOption.Position).Bind(option))
                ;
        }

    }
}
