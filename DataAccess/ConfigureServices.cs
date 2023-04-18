using DataAccess.Store.CustomerUseCase;
using DataAccess.Store.CustomerUseCase.Actions;
using DataAccess.Store.FormulaUseCase;
using DataAccess.Store.MicroChemistryUseCase;
using Fluxor;   

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddFluxor(options =>
            {
                options.ScanAssemblies(typeof(CustomerState).Assembly);
                options.ScanAssemblies(typeof(FormulaState).Assembly);
                options.ScanAssemblies(typeof(MicroChemistryState).Assembly);
                options.UseReduxDevTools();
            });
            return services;
        }
    }
}
