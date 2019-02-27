using System;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Hangfire.SimpleInjector
{
    public class SimpleInjectorJobActivator : JobActivator
    {
        private readonly Container _container;

        public SimpleInjectorJobActivator(Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public override object ActivateJob(Type jobType)
        {
            return _container.GetInstance(jobType);
        }

        public override JobActivatorScope BeginScope(JobActivatorContext context)
        {
            var scope = AsyncScopedLifestyle.BeginScope(_container);
            return new SimpleInjectorScope(_container, scope);
        }
    }
}
