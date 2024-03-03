using Autofac;
using ExchangeRates.Interfaces;

namespace ExchangeRates;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(this.GetType().Assembly)
            .Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IExchangeRateService))))
            .AsImplementedInterfaces()
            .InstancePerDependency();
    }
}