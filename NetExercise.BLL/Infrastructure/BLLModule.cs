using Autofac;
using NetExercise.BLL.Services;

namespace NetExercise.BLL.Infrastructure
{
    public class BllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConvertService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
